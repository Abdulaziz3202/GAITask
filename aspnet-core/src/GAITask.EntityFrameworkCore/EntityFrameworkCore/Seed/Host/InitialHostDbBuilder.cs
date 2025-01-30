namespace GAITask.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly GAITaskDbContext _context;

        public InitialHostDbBuilder(GAITaskDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
