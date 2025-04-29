using Microsoft.EntityFrameworkCore;
using Viajajunto.Models;
using Viajajunto.Services;
using Viajajunto.Data;
public class ItineraryServiceTests
{
    private readonly ItineraryService _itineraryService;
    private readonly ApplicationDbContext _context;
    private readonly int _testUserId;
    private readonly int _otherUserId;

    public ItineraryServiceTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // banco isolado por teste
            .Options;
        _context = new ApplicationDbContext(options);
        _itineraryService = new ItineraryService(_context);

        // Criar usuários de teste
        _testUserId = CreateTestUser("testuser").Id;
        _otherUserId = CreateTestUser("otheruser").Id;
    }

    private User CreateTestUser(string username)
    {
        var user = new User
        {
            Name = $"{username} name",
            Username = username,
            Email = $"{username}@example.com",
            Password = "123123"
        };
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    [Fact]
    public async Task CreateItineraryAsync_ShouldAddItineraryToDatabase()
    {
        // Arrange
        var itinerary = new Itinerary
        {
            Title = "Viagem para Paris",
            Description = "Minha primeira viagem internacional",
            UserId = _testUserId,
            IsPublic = true
        };

        // Act
        var result = await _itineraryService.CreateItineraryAsync(itinerary);

        // Assert
        var addedItinerary = await _context.Itineraries.FirstOrDefaultAsync(i => i.Title == "Viagem para Paris");
        Assert.NotNull(addedItinerary);
        Assert.Equal("Minha primeira viagem internacional", addedItinerary.Description);
        Assert.Equal(_testUserId, addedItinerary.UserId);
        Assert.True(addedItinerary.IsPublic);
        Assert.NotEqual(default(DateTime), addedItinerary.CreatedAt);
    }

    [Fact]
    public async Task GetItineraryByIdAsync_WithValidId_ShouldReturnItinerary()
    {
        // Arrange
        var itinerary = new Itinerary
        {
            Title = "Viagem para Roma",
            Description = "Visita ao Coliseu",
            UserId = _testUserId,
            IsPublic = true
        };
        _context.Itineraries.Add(itinerary);
        await _context.SaveChangesAsync();

        // Act
        var result = await _itineraryService.GetItineraryByIdAsync(itinerary.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Viagem para Roma", result.Title);
    }

    [Fact]
    public async Task GetItineraryByIdAsync_WithInvalidId_ShouldReturnNull()
    {
        // Act
        var result = await _itineraryService.GetItineraryByIdAsync(9999);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task ListItinerariesAsync_ShouldReturnOnlyAccessibleItineraries()
    {
        // Arrange
        var publicItinerary = new Itinerary
        {
            Title = "Viagem Pública",
            Description = "Para todos",
            UserId = _otherUserId,
            IsPublic = true
        };

        var privateItinerary = new Itinerary
        {
            Title = "Viagem Privada",
            Description = "Apenas para mim",
            UserId = _otherUserId,
            IsPublic = false
        };

        var ownItinerary = new Itinerary
        {
            Title = "Minha Viagem",
            Description = "Minhas férias",
            UserId = _testUserId,
            IsPublic = false
        };

        _context.Itineraries.AddRange(publicItinerary, privateItinerary, ownItinerary);
        await _context.SaveChangesAsync();

        // Act
        var result = await _itineraryService.ListItinerariesAsync(_testUserId);

        // Assert
        Assert.Equal(2, result.Count); // Deve retornar apenas a pública e a própria
        Assert.Contains(result, i => i.Title == "Viagem Pública");
        Assert.Contains(result, i => i.Title == "Minha Viagem");
        Assert.DoesNotContain(result, i => i.Title == "Viagem Privada");
    }

    [Fact]
    public async Task UpdateItineraryAsync_WithValidData_ShouldUpdateItinerary()
    {
        // Arrange
        var itinerary = new Itinerary
        {
            Title = "Viagem Original",
            Description = "Descrição original",
            UserId = _testUserId,
            IsPublic = false
        };
        _context.Itineraries.Add(itinerary);
        await _context.SaveChangesAsync();

        var updatedData = new Itinerary
        {
            Id = itinerary.Id,
            Title = "Viagem Atualizada",
            Description = "Nova descrição",
            IsPublic = true
        };

        // Act
        var result = await _itineraryService.UpdateItineraryAsync(updatedData);

        // Assert
        var updatedItinerary = await _context.Itineraries.FindAsync(itinerary.Id);
        Assert.Equal("Viagem Atualizada", updatedItinerary.Title);
        Assert.Equal("Nova descrição", updatedItinerary.Description);
        Assert.True(updatedItinerary.IsPublic);
    }

    [Fact]
    public async Task DeleteItineraryAsync_AsOwner_ShouldDeleteItinerary()
    {
        // Arrange
        var itinerary = new Itinerary
        {
            Title = "Viagem para Deletar",
            Description = "Será excluída",
            UserId = _testUserId,
            IsPublic = true
        };
        _context.Itineraries.Add(itinerary);
        await _context.SaveChangesAsync();

        // Act
        await _itineraryService.DeleteItineraryAsync(itinerary.Id);

        // Assert
        var deletedItinerary = await _context.Itineraries.FindAsync(itinerary.Id);
        Assert.Null(deletedItinerary);
    }

}