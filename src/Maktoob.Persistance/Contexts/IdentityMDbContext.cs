using System;
using System.Reflection;
using Maktoob.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Maktoob.Persistance.Contexts
{
    public class IdentityMDbContext : IdentityMDbContext<User, Role, string>
    // Organization, Project, Team, Notification, UserProfile, Photo,
    {
        public IdentityMDbContext() { }

        public IdentityMDbContext(DbContextOptions options) : base(options) { }
    }
    public class IdentityMDbContext<TUser, TRole, TKey>
    // TOrganization, TProject, TTeam, TNotification, TUserProfile, TPhoto 
    : IdentityMDbContext<TUser, TRole, TKey,
     // TOrganization, TProject, TTeam, TNotification, TUserProfile, TPhoto, OrgMembership<TKey>, TeamMembership<TKey>, AccessRight<TKey>, Diagram<TKey>,
     IdentityUserClaim<TKey>, IdentityUserRole<TKey>, IdentityUserLogin<TKey>, IdentityRoleClaim<TKey>, IdentityUserToken<TKey>>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>

        // where TOrganization : Organization<TKey>
        // where TProject : Project<TKey>
        // where TTeam : Team<TKey>
        // where TPhoto : Photo
        // where TNotification : Notification<TKey>
        // where TUserProfile : UserProfile<TKey>
    {
        public IdentityMDbContext() { }

        public IdentityMDbContext(DbContextOptions options) : base(options) { }
    }

    /// <summary>
    /// Base class for the Entity Framework database context used for Equtria
    /// </summary>
    /// <typeparam name="TOrganization">The type of organization objects.</typeparam>
    /// <typeparam name="TProject">The type of project objects.</typeparam>
    /// <typeparam name="TTeam">The type of team objects.</typeparam>
    /// <typeparam name="TDiagram">The type of diagram objects.</typeparam>
    /// <typeparam name="TKey">The type of the primary key for all entities</typeparam>
    /// <typeparam name="TOrgMembership">The type of organization membership object.</typeparam>
    /// <typeparam name="TTeamMembership">The type of team membership object.</typeparam>
    /// <typeparam name="TAccessRight">The type of project access right object.</typeparam>
    /// <typeparam name="TPhoto">The type of photo objects.</typeparam>
    /// <typeparam name="TNotification">The type of notification objects.</typeparam>
    /// <typeparam name="TUserProfile">The type of user profile objects.</>
    public abstract class IdentityMDbContext<TUser, TRole, TKey,
    // TOrganization, TProject, TTeam, TNotification, TUserProfile, TPhoto, TOrgMembership, TTeamMembership, TAccessRight, TDiagram,
    TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
        : IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
        where TUserClaim : IdentityUserClaim<TKey>
        where TUserRole : IdentityUserRole<TKey>
        where TUserLogin : IdentityUserLogin<TKey>
        where TRoleClaim : IdentityRoleClaim<TKey>
        where TUserToken : IdentityUserToken<TKey>
        // where TOrganization : Organization<TKey>
        // where TProject : Project<TKey>
        // where TTeam : Team<TKey>
        // where TDiagram : Diagram<TKey>
        // where TOrgMembership : OrgMembership<TKey>
        // where TTeamMembership : TeamMembership<TKey>
        // where TAccessRight : AccessRight<TKey>
        // where TPhoto : Photo
        // where TNotification : Notification<TKey>
        // where TUserProfile : UserProfile<TKey>
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public IdentityMDbContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        protected IdentityMDbContext() { }

        // /// <summary>
        // /// Gets or sets the <see cref="DbSet{TEntity}"/> of organizations.
        // /// </summary>
        // public DbSet<TOrganization> Organizations { get; set; }

        // /// <summary>
        // /// Gets or sets the <see cref="DbSet{TEntity}"/> of projects.
        // /// </summary>
        // public DbSet<TProject> Projects { get; set; }

        // /// <summary>
        // /// Gets or sets the <see cref="DbSet{TEntity}"/> of diagrams.
        // /// </summary>
        // public DbSet<TDiagram> Diagrams { get; set; }

        // /// <summary>
        // /// Gets or sets the <see cref="DbSet{TEntity}"/> of teams.
        // /// </summary>
        // public DbSet<TTeam> Teams { get; set; }

        // /// <summary>
        // /// Gets or sets the <see cref="DbSet{TEntity}"/> of notifications.
        // /// </summary>
        // public DbSet<TNotification> Notifications { get; set; }

        // /// <summary>
        // /// Gets or sets the <see cref="DbSet{TEntity}"/> of User profiles.
        // /// </summary>
        // public DbSet<TUserProfile> UserProfiles { get; set; }

        // /// <summary>
        // /// Gets or sets the <see cref="DbSet{TEntity}"/> of photos.
        // /// </summary>
        // public DbSet<TPhoto> Photos { get; set; }

        // /// <summary>
        // /// Gets or sets the <see cref="DbSet{TEntity}"/> of Organization memberships.
        // /// </summary>
        // public DbSet<TOrgMembership> OrgMemberships { get; set; }

        // /// <summary>
        // /// Gets or sets the <see cref="DbSet{TEntity}"/> of Team membership.
        // /// </summary>
        // public DbSet<TTeamMembership> TeamMemberships { get; set; }

        // /// <summary>
        // /// Gets or sets the <see cref="DbSet{TEntity}"/> of Project access rights.
        // /// </summary>
        // public DbSet<TAccessRight> AccessRights { get; set; }
        /// <summary>
        /// Configures the schema needed for the Equtria framework.
        /// </summary>
        /// <param name="builder">
        /// The builder being used to construct the model for this context.
        /// </param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // use defualt Identity configuration
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetCallingAssembly());
            // configure users table
            // builder.Entity<TUser>(b =>
            // {
            //     b.ToTable("Users");
            //     // one user can belong to many organizations
            //     b.HasMany<TOrgMembership>()
            //         .WithOne()
            //         .HasForeignKey(om => om.UserId)
            //         .IsRequired();

            //     // one user can belong to many teams
            //     b.HasMany<TTeamMembership>()
            //         .WithOne()
            //         .HasForeignKey(tm => tm.UserId)
            //         .IsRequired();

            //     // one user can own one profilea and one profile can be owned by one user
            //     b.HasOne<TUserProfile>()
            //         .WithOne()
            //         .HasForeignKey<TUserProfile>(up => up.UserId)
            //         .IsRequired();

            //     // one user can have many notifications
            //     b.HasMany<TNotification>()
            //         .WithOne()
            //         .HasForeignKey(n => n.UserId)
            //         .IsRequired();
            // });
            // builder.Entity<TRole>(b => { b.ToTable("Roles"); });
            // builder.Entity<TUserRole>(b => { b.ToTable("UserRoles"); });
            // builder.Entity<TUserClaim>(b => { b.ToTable("UserClaims"); });
            // builder.Entity<TUserLogin>(b => { b.ToTable("UserLogins"); });
            // builder.Entity<TUserToken>(b => { b.ToTable("UserTokens"); });
            // builder.Entity<TRoleClaim>(b => { b.ToTable("RoleClaims"); });

            // // configure organizations table
            // builder.Entity<TOrganization>(b =>
            // {
            //     // one organization can contain many members
            //     b.HasMany<TOrgMembership>()
            //         .WithOne()
            //         .HasForeignKey(om => om.OrgId)
            //         .IsRequired();

            //     // one organization can contain many teams
            //     b.HasMany<TTeam>()
            //         .WithOne()
            //         .HasForeignKey(t => t.OrgId)
            //         .IsRequired();

            //     // one organization can own many projects
            //     b.HasMany<TProject>()
            //         .WithOne()
            //         .HasForeignKey(p => p.OrgId)
            //         .IsRequired();
            // });

            // // configure projects table
            // builder.Entity<TProject>(b =>
            // {
            //     // one project can belong to one and only one organization
            //     b.HasIndex(p => new { p.OrgId, p.Id }).IsUnique();
            //     b.HasIndex(p => p.OrgId);

            //     b.HasMany<TAccessRight>().WithOne().HasForeignKey(ar => ar.ProjectId).IsRequired();
            // });
            // builder.Entity<TDiagram>(b => { });

            // // configure teams table
            // builder.Entity<TTeam>(b =>
            // {
            //     // one team can contain many members
            //     b.HasMany<TTeamMembership>()
            //         .WithOne()
            //         .HasForeignKey(tm => tm.TeamId)
            //         .IsRequired();

            //     b.HasMany<TAccessRight>().WithOne().HasForeignKey(ar => ar.TeamId).IsRequired();
            // });
            // builder.Entity<TNotification>(b => { });
            // builder.Entity<TUserProfile>(b => { });
            // builder.Entity<TPhoto>(b => { });
            // builder.Entity<TOrgMembership>(b => { b.HasKey(om => new { om.OrgId, om.UserId }); });
            // builder.Entity<TTeamMembership>(b => { b.HasKey(tm => new { tm.TeamId, tm.UserId }); });
            // builder.Entity<TAccessRight>(b => { b.HasKey(ar => new { ar.ProjectId, ar.TeamId }); });
        }
    }
}