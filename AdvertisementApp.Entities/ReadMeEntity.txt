@Entity
{
	Entity is a semantic i.e. relating to meaning in language or logic. An entity is something that exists in itself,
	actually or potentially, concretely or abstractly, physically or not. It needs not be of material existence.

	https://i.stack.imgur.com/PndOc.png

	An entity usually refers to something, anything really, that has a unique and separate existence.
	In software development this word is almost only used to denote that one instance is different from another instance and they are independent of each other.

	A class, on the other hand, defines or contains the definition of an object.
	Once that object is constructed based on the definition, then you get your instance or object instance.
}

@NavigationProperty
{
	Relationships:In relational databases, relationships (also called associations) between tables are defined through foreign keys.
	A foreign key (FK) is a column or combination of columns that is used to establish and enforce a link between the data in two tables.
	There are generally three types of relationships: one-to-one, one-to-many, and many-to-many. In a one-to-many relationship,
	the foreign key is defined on the table that represents the many end of the relationship. The many-to-many relationship involves
	defining a third table (called a junction or join table), whose primary key is composed of the foreign keys from both related tables.
	In a one-to-one relationship, the primary key acts additionally as a foreign key and there is no separate foreign key column for either table.

	Navigation properties provide a way to navigate an association between two entity types. Every object can have a navigation property
	for every relationship in which it participates. Navigation properties allow you to navigate and manage relationships in both directions,
	returning either a reference object (if the multiplicity is either one or zero-or-one) or a collection (if the multiplicity is many).
	You may also choose to have one-way navigation, in which case you define the navigation property on only one of the types that participates in the relationship and not on both.
}