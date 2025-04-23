using Microsoft.EntityFrameworkCore;
using Viajajunto.Models;
using Viajajunto.Services;
using Viajajunto.Data;
public class UserServiceTests
{
    private readonly UserService _userService;
    private readonly ApplicationDbContext _context;

    public UserServiceTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // banco isolado por teste
            .Options;

        _context = new ApplicationDbContext(options);
        _userService = new UserService(_context);
    }

    [Fact]
    public async Task AddUser_ShouldAddUserToDatabase()
    {
        var user = new User { Name = "John Doe", Username = "johndoe", Email = "johndoe@example.com", Password = "123123" };

        await _userService.AddUser(user);

        var addedUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == "johndoe");

        Assert.NotNull(addedUser);
        Assert.Equal("John Doe", addedUser.Name);
        Assert.Equal("johndoe@example.com", addedUser.Email);
    }
}
