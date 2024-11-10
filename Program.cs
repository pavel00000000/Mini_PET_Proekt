using Mini_PET_Proekt.Services;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

// ����������� ������� BookService
builder.Services.AddTransient<IBookService, BookService>();

// ����������� MySQL �����������
builder.Services.AddTransient<MySqlConnection>(sp =>
    new MySqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ��������� ��������� ��������� ��������
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
