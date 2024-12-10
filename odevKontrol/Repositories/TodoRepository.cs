using odevKontrol.Models;

namespace odevKontrol.Repositories
{
    public class TodoRepository : GenericRepository<Todo>
    {
        public TodoRepository(AppDbContext context) : base(context)
        {

        }
    }
}
