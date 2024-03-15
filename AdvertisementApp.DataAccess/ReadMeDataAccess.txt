CONFIGURATIONS
@IEntityTypeConfiguration
{
    Allows configuration for an entity type to be factored into a separate class, rather than in-line in OnModelCreating(ModelBuilder).
	Implement this interface, applying configuration for the entity in the Configure(EntityTypeBuilder<TEntity>) method, and then apply
	the configuration to the model using ApplyConfiguration<TEntity>(IEntityTypeConfiguration<TEntity>) in OnModelCreating(ModelBuilder).
}

CONTEXTS
@DbContext
{
	A DbContext instance represents a session with the database and can be used to query and save instances of your entities.
	DbContext is a combination of the Unit Of Work and Repository patterns.
}

@DbSet
{
	DbSet represents the collection of all entities in context or that can be queried from a database of a particular type.
	DbSet objects are created from a DbContext using the DbContext.Set method.
}

@DbContextOptions
{
	This is an internal API that supports the Entity Framework Core infrastructure and not subject to the same compatibility standards as public APIs. 
}

@ModelBuilder
{
	The ModelBuilder is the class which is responsible for building the Model. The ModelBuilder builds the initial model from the entity classes that
	have DbSet Property in the context class, that we derive from the DbContext class. It then uses the conventions to create primary keys, Foreign keys, relationships etc.
}

REPOSITORY
@IQueryable
{
	IQueryable is suitable for querying data from out-memory (like remote database, service) collections. While querying data from a database,
	IQueryable executes a "select query" on server-side with all filters. Queryable is beneficial for LINQ to SQL queries.
}

UNITOFWORK
@Uow
{
	Unit of Work is referred to as a single transaction that involves multiple operations of insert/update/delete and so on kinds. To say it in simple words,
	it means that for a specific user action (say registration on a website), all the transactions like insert/update/delete and so on are done in one single transaction,
	rather then doing multiple database transactions. This means, one unit of work here involves insert/update/delete operations, all in one single transaction.
}

