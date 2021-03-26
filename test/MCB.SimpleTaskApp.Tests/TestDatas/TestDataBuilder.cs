using MCB.SimpleTaskApp.EntityFrameworkCore;
using MCB.SimpleTaskApp.Tasks;

namespace MCB.SimpleTaskApp.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly SimpleTaskAppDbContext _context;

        public TestDataBuilder(SimpleTaskAppDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            _context.Tasks.AddRange(
                new Task("Follow the white rabbit", "Follow the white rabbit in order to know the reality."),
                new Task("Clean your room") { State = TaskState.Completed}
                );
        }
    }
}