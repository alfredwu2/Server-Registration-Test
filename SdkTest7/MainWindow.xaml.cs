using Microsoft.Azure.Management.Fluent;
//using Microsoft.Azure.Management.ResourceManager.Fluent;
//using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Rest;
using Microsoft.Rest.Azure.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Azure.Management.ResourceManager;

namespace SdkTest7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //AzureCredentials azureCredentials = null;
        string clientID = "1950a258-227b-4e31-a9cf-717495945fc2";
        string redirectUri = "urn:ietf:wg:oauth:2.0:oob";

        public async void loginAsync()
        {

            try
            {

                ActiveDirectoryClientSettings activeDirectoryClientSettings = new ActiveDirectoryClientSettings(clientID, new Uri(redirectUri));
                activeDirectoryClientSettings.PromptBehavior = Microsoft.IdentityModel.Clients.ActiveDirectory.PromptBehavior.Always;
                activeDirectoryClientSettings.OwnerWindow = this;


                ServiceClientCredentials credentials = await UserTokenProvider.LoginWithPromptAsync(activeDirectoryClientSettings);

                //MessageBox.Show(credentials.TenantId);

                //ResourceManagementClient resourceManagementClient = new Microsoft.Azure.Management.ResourceManager.ResourceManagementClient(credentials);

                SubscriptionClient subClient = new SubscriptionClient(credentials);
                

                var subs = await subClient.Subscriptions.ListAsync();
                


                //TenantsOperationsExtensions 

                //{
                //    SubscriptionId = SubscriptionId,
                //    GenerateClientRequestId = true,
                //    LongRunningOperationRetryTimeout = 60 * 6
                //};

                //AzureCredentials azureCredentials = new AzureCredentials(credentials, credentials, "common", AzureEnvironment.AzureGlobalCloud);

                //string tenant = Azure
                //    .Authenticate(azureCredentials)
                //    .TenantId;

                //MessageBox.Show(tenant);


                //var serviceClient = await credentials.InitializeServiceClient();

                MessageBox.Show(credentials.ToString());


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }




            //azureCredentials = new AzureCredentials(credentials, credentials, tenantID, AzureEnvironment.AzureGlobalCloud);
        }

        public MainWindow()
        {
            InitializeComponent();


            loginAsync();


        }
    }
}
