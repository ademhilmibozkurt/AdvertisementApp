@Dtos
{
	DTO stands for “Data Transfer Object” It is a design pattern used in software development to transfer data between differentlayers or components of an application.
	The primary purpose of a DTO is to encapsulate data and transport it from one part of the application to another without exposing the underlying data structures
	or implementation details. DTOs are commonly used in client-server architectures, where data needs to be exchanged between the client-side and server-side
	components. They help in decoupling the data representation from the business logic or database schema, providing a clear separation of concerns.


	// characteristics
	Data Carrier: DTOs are simple data containers that hold data and may include properties to represent the data fields. They typically contain no behavior or business logic.

    Serializable: DTOs are often designed to be easily serialized and deserialized, allowing them to be sent over the network or stored in a persistent storage system.

	Immutable: Immutable DTOs ensure that the transported data remains unchanged during its journey through different layers, reducing the chances of unintended modifications.
}