namespace LeaveManagmentWebApp.Data
{
    public abstract class BaseEntity // to not repeat it has to have inheritance working with it (cant by itself)
    {
        public int Id { get; set; }

        public DateTime DataCreated { get; set; }

        public DateTime DataModified { get; set; }

    }
}