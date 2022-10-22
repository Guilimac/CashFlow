using CashFlow.MemoryDb;
using CashFlow.MemoryDb.Entities;
using CashFlow.Services;
using CashFlow.Services.Dtos;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRegisterDb, RegisterDb>();
builder.Services.AddScoped<IRegisterService, RegisterService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();



app.MapPost("/register", (IRegisterService registerService, [FromBody]Register register) =>
{
    if (register != null)
    {
        registerService.AddRegister(register);
        return Results.Created($"/ register /`{register.Id}", register);
    }
    else
    {
        return Results.BadRequest("no register inserted");
    }
}
).WithName("createRegister")
.ProducesValidationProblem()
.Produces<Register>(StatusCodes.Status201Created);

app.MapGet("/register/{id}", (IRegisterService registerService, Guid id) =>
    registerService.GetRegister(id)
    is Register register
    ? Results.Ok(register)
    : Results.NotFound())
    .WithName("GetRegisterById")
    .Produces<Register>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound);

app.MapGet("/registers",(IRegisterService registerService) =>
    registerService.GetAllRegisters()
        is IEnumerable<Register> registers
    ? Results.Ok(registers)
    : Results.NotFound())
    .WithName("GetRegister")
    .Produces<Register>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound);
app.MapGet("/registerByDate/{date}",(IRegisterService registerService, DateTime date)=>
    registerService.GetRegistersByDate(date)
    is RegistersDto registers
    ? Results.Ok(registers)
    : Results.NotFound())
    .WithName("GetRegisterByDate")
    .Produces<Register>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound);

app.Run();