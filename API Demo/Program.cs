using API_Demo.Exceptions;
using ApiExceptionPipelineV2._0;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionPipeline(
    exceptionDecoder: ExceptionDecoder.CustomExceptions,
    exceptionMaps: ExceptionDecoder.CustomExceptionMaps
);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
