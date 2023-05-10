using FluentNHibernate.Conventions.AcceptanceCriteria;
using todolist.controller;
using todolist.domain;
using todolist.domain.entity;
using todolist.domain.persistence;
using todolist.domain.repositories;
using todolist.domain.repository;
using todolist.useCase.TaskItem;
using todolist.useCase.TaskList;
using ISession = NHibernate.ISession;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configFilePath = NHibernateHelper.getFullPath("hibernate.cfg.xml");
NHibernateHelper.Initialize(configFilePath);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddScoped<ISession>(factory =>
// {
//     var configuration = new NHibernate.Cfg.Configuration();
//     configuration.Configure(configFilePath);
//     var sessionFactory = configuration.BuildSessionFactory();
//     return sessionFactory.OpenSession();
// });

builder.Services.AddScoped<ISession>(factory => NHibernateHelper.OpenSession());

builder.Services.AddScoped<ITaskItemRepository, TaskItemRepository>();
builder.Services.AddScoped<ITaskListRepository, TaskListRepository>();

builder.Services.AddScoped<TaskItemRepository>();
builder.Services.AddScoped<TaskListRepository>();

builder.Services.AddScoped<TaskItemMap>();
builder.Services.AddScoped<TaskListMap>();

builder.Services.AddScoped<CreateTaskItemUseCase>();
builder.Services.AddScoped<DeleteTaskItemUseCase>();
builder.Services.AddScoped<FindTaskItemUseCase>();
builder.Services.AddScoped<UpdateTaskItemUseCase>();

builder.Services.AddScoped<CreateTaskListUseCase>();
builder.Services.AddScoped<DeleteTaskListUseCase>();
builder.Services.AddScoped<FindTaskListUseCase>();
builder.Services.AddScoped<UpdateTaskListUseCase>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();