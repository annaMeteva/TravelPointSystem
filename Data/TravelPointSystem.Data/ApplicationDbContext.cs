namespace TravelPointSystem.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using TravelPointSystem.Data.Common.Models;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Data.Models.MappingTables;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bus> Buses { get; set; }

        public DbSet<Destination> Destinations { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<FlightCompany> FlightCompanies { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<OrganizedTrip> OrganizedTrips { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<ReservationTourist> ReservationTourists { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<Tourist> Tourists { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);
        
        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private static void ConfigureUserIdentityRelations(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Roles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-many relationship between ApplicationUsers and Reservations
            builder.Entity<ApplicationUser>()
                .HasMany(au => au.Reservations)
                .WithOne(r => r.Creator)
                .HasForeignKey(r => r.CreatorId);

            builder.Entity<Reservation>()
                .HasOne<ApplicationUser>(r => r.Creator)
                .WithMany(au => au.Reservations)
                .HasForeignKey(r => r.CreatorId);

            // One-to-many relationship between OrganizedTrips and Destinations
            builder.Entity<OrganizedTrip>()
                .HasOne<Destination>(ot => ot.Destination)
                .WithMany(d => d.OrganizedTrips)
                .HasForeignKey(ot => ot.DestinationId);

            builder.Entity<Destination>()
                .HasMany<OrganizedTrip>(d => d.OrganizedTrips)
                .WithOne(ot => ot.Destination)
                .HasForeignKey(ot => ot.DestinationId);

            // One-to-many relationship between OrganizedTrips and Hotels
            builder.Entity<OrganizedTrip>()
               .HasOne<Hotel>(ot => ot.Hotel)
               .WithMany(h => h.OrganizedTrips)
               .HasForeignKey(ot => ot.HotelId);

            builder.Entity<Hotel>()
                .HasMany<OrganizedTrip>(h => h.OrganizedTrips)
                .WithOne(ot => ot.Hotel)
                .HasForeignKey(ot => ot.HotelId);

            // One-to-many relationship between Buses and Destinations
            builder.Entity<Bus>()
                .HasOne<Destination>(b => b.StartPoint)
                .WithMany(d => d.DepartureBuses)
                .HasForeignKey(b => b.StartPointId);

            builder.Entity<Bus>()
                .HasOne<Destination>(b => b.EndPoint)
                .WithMany(d => d.DepartingBuses)
                .HasForeignKey(b => b.EndPointId);

            builder.Entity<Destination>()
                .HasMany(d => d.DepartureBuses)
                .WithOne(b => b.StartPoint)
                .HasForeignKey(b => b.StartPointId);

            builder.Entity<Destination>()
                .HasMany(d => d.DepartingBuses)
                .WithOne(b => b.EndPoint)
                .HasForeignKey(b => b.EndPointId);

            // One-to-many relationship between Destinations and Hotels
            builder.Entity<Destination>()
                .HasMany(d => d.Hotels)
                .WithOne(h => h.Destination)
                .HasForeignKey(h => h.DestinationId);

            builder.Entity<Hotel>()
                .HasOne<Destination>(h => h.Destination)
                .WithMany(d => d.Hotels)
                .HasForeignKey(h => h.DestinationId);

            // One-to-many relationship between Destinations and Flights
            builder.Entity<Destination>()
                .HasMany(d => d.DepartureFlights)
                .WithOne(f => f.StartPoint)
                .HasForeignKey(f => f.StartPointId);

            builder.Entity<Destination>()
                .HasMany(d => d.DepartingFlights)
                .WithOne(f => f.EndPoint)
                .HasForeignKey(f => f.EndPointId);

            builder.Entity<Flight>()
                .HasOne<Destination>(f => f.StartPoint)
                .WithMany(d => d.DepartureFlights)
                .HasForeignKey(f => f.StartPointId);

            builder.Entity<Flight>()
                .HasOne<Destination>(f => f.EndPoint)
                .WithMany(d => d.DepartingFlights)
                .HasForeignKey(f => f.EndPointId);

            // One-to-many relationship between Flights and FlightCompanies
            builder.Entity<Flight>()
                .HasOne<FlightCompany>(f => f.Company)
                .WithMany(fc => fc.Flights)
                .HasForeignKey(f => f.CompanyId);

            builder.Entity<FlightCompany>()
                .HasMany(fc => fc.Flights)
                .WithOne(f => f.Company)
                .HasForeignKey(f => f.CompanyId);

            // One-to-many relationship between Hotels and Reservations
            builder.Entity<Reservation>()
                .HasOne<Hotel>(r => r.Hotel)
                .WithMany(h => h.Reservations)
                .HasForeignKey(r => r.HotelId);

            builder.Entity<Hotel>()
                .HasMany(h => h.Reservations)
                .WithOne(r => r.Hotel)
                .HasForeignKey(r => r.HotelId);

            // One-to-many relationship between OrganizedTrips and Reservations
            builder.Entity<Reservation>()
                .HasOne<OrganizedTrip>(r => r.OrganizedTrip)
                .WithMany(ot => ot.Reservations)
                .HasForeignKey(r => r.OrganizedTripId);

            builder.Entity<OrganizedTrip>()
                .HasMany(ot => ot.Reservations)
                .WithOne(r => r.OrganizedTrip)
                .HasForeignKey(r => r.OrganizedTripId);

            // One-to-many relationship between Flight and Reservations
            builder.Entity<Reservation>()
                .HasOne<Flight>(r => r.Flight)
                .WithMany(f => f.Reservations)
                .HasForeignKey(r => r.FlightId);

            builder.Entity<Flight>()
                .HasMany(f => f.Reservations)
                .WithOne(r => r.Flight)
                .HasForeignKey(r => r.FlightId);

            // One-to-many relationship between Flight and Reservations
            builder.Entity<Reservation>()
                .HasOne<Bus>(r => r.Bus)
                .WithMany(b => b.Reservations)
                .HasForeignKey(r => r.BusId);

            builder.Entity<Bus>()
                .HasMany(b => b.Reservations)
                .WithOne(r => r.Bus)
                .HasForeignKey(r => r.BusId);

            // Many-to-many relationship between Reservations and Tourists
            builder.Entity<ReservationTourist>()
                .HasKey(rt => new { rt.ReservationId, rt.TouristId });

            builder.Entity<ReservationTourist>()
                .HasOne(rt => rt.Reservation)
                .WithMany(r => r.Tourists)
                .HasForeignKey(rt => rt.ReservationId);

            builder.Entity<ReservationTourist>()
                .HasOne(rt => rt.Tourist)
                .WithMany(t => t.Reservations)
                .HasForeignKey(rt => rt.TouristId);
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
