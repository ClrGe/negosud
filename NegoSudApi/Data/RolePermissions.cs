namespace NegoSudApi.Data
{
    public class RolePermissions
    {
        #region Roles
        public const string Admin = "Admin";
        public const string Employee = "Employee";
        public const string Customer = "Customer";

        public static List<string> Roles = new()
        {
            Admin, Employee, Customer,
        };
        #endregion

        #region Permissions
        public const string CanGetAddresses = "CanGetAddresses";
        public const string CanEditAddress = "CanEditAddress";
        public const string CanDeleteAddress = "CanDeleteAddress";

        public const string CanAddBottle = "CanAddBottle";
        public const string CanEditBottle = "CanEditBottle";
        public const string CanDeleteBottle = "CanDeleteBottle";

        public const string CanAddCity = "CanAddCity";
        public const string CanEditCity = "CanEditCity";
        public const string CanDeleteCity = "CanDeleteCity";

        public const string CanAddCountry = "CanAddCountry";
        public const string CanEditCountry = "CanEditCountry";
        public const string CanDeleteCountry = "CanDeleteCountry";

        public const string CanGetCustomerOrder = "CanGetCustomerOrder";
        public const string CanGetCustomerOrders = "CanGetCustomerOrders";
        public const string CanAddCustomerOrder = "CanAddCustomerOrder";
        public const string CanEditCustomerOrder = "CanEditCustomerOrder";
        public const string CanDeleteCustomerOrder = "CanDeleteCustomerOrder";

        public const string CanAddGrape = "CanAddGrape";
        public const string CanEditGrape = "CanEditGrape";
        public const string CanDeleteGrape = "CanDeleteGrape";

        public const string CanGetPermission = "CanGetPermission";
        public const string CanAddPermission = "CanAddPermission";
        public const string CanEditPermission = "CanEditPermission";
        public const string CanDeletePermission = "CanDeletePermission";

        public const string CanAddProducer = "CanAddProducer";
        public const string CanEditProducer = "CanEditProducer";
        public const string CanDeleteProducer = "CanDeleteProducer";

        public const string CanAddRegion = "CanAddRegion";
        public const string CanEditRegion = "CanEditRegion";
        public const string CanDeleteRegion = "CanDeleteRegion";

        public const string CanGetRole = "CanGetRole";
        public const string CanAddRole = "CanAddRole";
        public const string CanEditRole = "CanEditRole";
        public const string CanDeleteRole = "CanDeleteRole";

        public const string CanGetStorageLocation = "CanGetStorageLocation";
        public const string CanAddStorageLocation = "CanAddStorageLocation";
        public const string CanEditStorageLocation = "CanEditStorageLocation";
        public const string CanDeleteStorageLocation = "CanDeleteStorageLocation";

        public const string CanGetSupplier = "CanGetSupplier";
        public const string CanAddSupplier = "CanAddSupplier";
        public const string CanEditSupplier = "CanEditSupplier";
        public const string CanDeleteSupplier = "CanDeleteSupplier";

        public const string CanGetSupplierOrder = "CanGetSupplierOrder";
        public const string CanAddSupplierOrder = "CanAddSupplierOrder";
        public const string CanEditSupplierOrder = "CanEditSupplierOrder";
        public const string CanDeleteSupplierOrder = "CanDeleteSupplierOrder";

        public const string CanGetUser = "CanGetUser";
        public const string CanGetUsers = "CanGetUsers";
        public const string CanAddUser = "CanAddUser";
        public const string CanEditUser = "CanEditUser";
        public const string CanDeleteUser = "CanDeleteUser";

        public const string CanAddWineLabel = "CanAddWineLabel";
        public const string CanEditWineLabel = "CanEditWineLabel";
        public const string CanDeleteWineLabel = "CanDeleteWineLabel";
        
        public const string CanGetVat = "CanGetVat";
        public const string CanAddVat = "CanAddVat";
        public const string CanEditVat = "CanEditVat";
        public const string CanDeleteVat = "CanDeleteVat";
        public const string CandSendEmail = "CanSendEmail";

        #endregion

        public static List<string> DefaultCustomerPermissions = new()
        {
            CanEditAddress, CanDeleteAddress, CanAddCustomerOrder, CanGetCustomerOrder, CanEditCustomerOrder, CanDeleteCustomerOrder,
            CanGetUser, CanEditUser, CanDeleteUser,CanGetVat, CandSendEmail,
        };

        public static List<string> DefaultEmployeePermissions = new(DefaultCustomerPermissions)
        {
            CanAddBottle, CanEditBottle, CanDeleteBottle, 
            CanAddCity, CanEditCity, CanDeleteCity,
            CanAddCountry, CanEditCountry, CanDeleteCountry,
            CanGetCustomerOrders,
            CanAddProducer, CanEditProducer, CanDeleteProducer,
            CanGetRole,
            CanGetStorageLocation, CanAddStorageLocation, CanEditStorageLocation, CanDeleteStorageLocation,
            CanGetSupplier, CanAddSupplier, CanEditSupplier, CanDeleteSupplier,
            CanGetSupplierOrder, CanAddSupplierOrder, CanEditSupplierOrder, CanDeleteSupplierOrder,
            CanAddWineLabel, CanEditWineLabel, CanDeleteWineLabel, CanAddVat, CanEditVat

        }; 

    }
}
