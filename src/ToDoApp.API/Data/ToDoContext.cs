﻿using Microsoft.EntityFrameworkCore;
using ToDoApp.API.Models;

namespace ToDoApp.API.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {

        }
        public DbSet<AccountInfo> AccountInfos { get; set; }
        public DbSet<ToDoInfo> ToDoInfos { get; set; }
        public DbSet<MemoInfo> MemoInfos { get; set; }
    }
}
