using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Help_desk_db
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        #region <!--DbSet-->
        public DbSet<Statuse> Statuses { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupsPermission> GroupsPermissions { get; set; }
        public DbSet<UsersGroup> UsersGroups { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Invite> Invites { get; set; }
        public DbSet<InvitesGroup> InvitesGroups { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<TemplatesCategory> TemplatesCategories { get; set; }
        public DbSet<Template> Templates { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //strings for using SoftDelee in concret Tables
            modelBuilder.Entity<GroupsPermission>().Property<bool>("isDeleted");
            modelBuilder.Entity<GroupsPermission>().HasQueryFilter(m => EF.Property<bool>(m, "isDeleted") == false);

            modelBuilder.Entity<UsersGroup>().Property<bool>("isDeleted");
            modelBuilder.Entity<UsersGroup>().HasQueryFilter(m => EF.Property<bool>(m, "isDeleted") == false);

            modelBuilder.Entity<InvitesGroup>().Property<bool>("isDeleted");
            modelBuilder.Entity<InvitesGroup>().HasQueryFilter(m => EF.Property<bool>(m, "isDeleted") == false);

            #region <!--strings to create a many-to-many relationships-->
            //GroupsPermission
            modelBuilder.Entity<GroupsPermission>()
           .HasKey(t => new { t.GroupId, t.PermissionId });

            modelBuilder.Entity<GroupsPermission>()
                .HasOne(sc => sc.Group)
                .WithMany(s => s.GroupsPermissions)
                .HasForeignKey(sc => sc.GroupId);

            modelBuilder.Entity<GroupsPermission>()
                .HasOne(sc => sc.Permission)
                .WithMany(c => c.GroupsPermissions)
                .HasForeignKey(sc => sc.PermissionId);

            //UsersGroup
            modelBuilder.Entity<UsersGroup>()
               .HasKey(t => new { t.UserId, t.GroupId });

            modelBuilder.Entity<UsersGroup>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.UsersGroups)
                .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<UsersGroup>()
                .HasOne(sc => sc.Group)
                .WithMany(c => c.UsersGroups)
                .HasForeignKey(sc => sc.GroupId);

            //InvitesGroup
            modelBuilder.Entity<InvitesGroup>()
              .HasKey(t => new { t.InviteId, t.GroupId });

            modelBuilder.Entity<InvitesGroup>()
                .HasOne(sc => sc.Invite)
                .WithMany(s => s.InvitesGroups)
                .HasForeignKey(sc => sc.InviteId);

            modelBuilder.Entity<InvitesGroup>()
                .HasOne(sc => sc.Group)
                .WithMany(c => c.InvitesGroups)
                .HasForeignKey(sc => sc.GroupId);
            #endregion

            //strings to create a one-to-one relationships
           
            modelBuilder
            .Entity<Company>()
            .HasOne(u => u.Department)
            .WithOne(p => p.Company)
            .HasForeignKey<Department>(p => p.CompanyId);

            modelBuilder
           .Entity<Statuse>()
           .HasOne(u => u.Ticket)
           .WithOne(p => p.Statuse)
           .HasForeignKey<Ticket>(p => p.StatusId);

            modelBuilder
           .Entity<Priority>()
           .HasOne(u => u.Ticket)
           .WithOne(p => p.Priority)
           .HasForeignKey<Ticket>(p => p.PriorityId);

            modelBuilder
          .Entity<Template>()
          .HasOne(u => u.Ticket)
          .WithOne(p => p.Template)
          .HasForeignKey<Ticket>(p => p.TemplateId);

            modelBuilder
         .Entity<Group>()
         .HasOne(u => u.Template)
         .WithOne(p => p.Group)
         .HasForeignKey<Template>(p => p.GroupId);

            modelBuilder
        .Entity<Department>()
        .HasOne(u => u.User)
        .WithOne(p => p.Department)
        .HasForeignKey<User>(p => p.DepartmentId);

            modelBuilder
      .Entity<Comment>()
      .HasOne(u => u.Attachment)
      .WithOne(p => p.Comment)
      .HasForeignKey<Attachment>(p => p.CommentId);

            #region <!-- tables naming -->
            modelBuilder.Entity<Statuse>().ToTable("statuses");
            modelBuilder.Entity<Permission>().ToTable("permissions");
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Priority>().ToTable("priorities");
            modelBuilder.Entity<Company>().ToTable("companies");
            modelBuilder.Entity<Group>().ToTable("groups");
            modelBuilder.Entity<GroupsPermission>().ToTable("groups_permissions");
            modelBuilder.Entity<UsersGroup>().ToTable("users_groups");
            modelBuilder.Entity<Department>().ToTable("departments");
            modelBuilder.Entity<Attachment>().ToTable("attachments");
            modelBuilder.Entity<Invite>().ToTable("invites");
            modelBuilder.Entity<InvitesGroup>().ToTable("invites_groups");
            modelBuilder.Entity<Ticket>().ToTable("tickets");
            modelBuilder.Entity<Comment>().ToTable("comments");
            modelBuilder.Entity<TemplatesCategory>().ToTable("templates_categories");
            modelBuilder.Entity<Template>().ToTable("templates");
            #endregion
        }
        #region <!--region with methods that make SoftDelete work -->
        public override int SaveChanges()
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["isDeleted"] = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["isDeleted"] = true;
                        break;
                }
            }
        }
        #endregion
    }
}
