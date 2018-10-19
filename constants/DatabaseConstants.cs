namespace INAH.constants.database
{
    class DatabaseConstants
    {
        public const string DATABASE_FILE = "data.sdf";
        public const string DATABASE_STRING_CONNECTION = "DataSource=\"" + DATABASE_FILE + "\"; Password=\"INAH123\"; Encrypt = TRUE;";

        public const string CREATE_TABLE_CREDENTIALS = "CREATE TABLE [credentials] (" +
                                                            "[Id] int IDENTITY(1,1)  NOT NULL, " +
                                                            "[User] nvarchar(30)  NOT NULL, " +
                                                            "[Key] nvarchar(64)  NOT NULL," +
                                                            "PRIMARY KEY([Id])" +
                                                        ");";

        public const string CREATE_TABLE_ = "";
    }
}
