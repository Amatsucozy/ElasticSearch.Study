// namespace ElasticSearch.API.Core.Models.LogicalExtensionFields;
//
// public sealed class BooleanField
// {
//     public int Id { get; set; }
//
//     public string Name { get; set; }
//
//     public bool Value { get; set; }
//
//     public Guid TenantId { get; set; }
//
//     public BooleanField(ContactExtensionField contactExtensionField)
//     {
//         if (contactExtensionField.Type != DataTypes.Boolean)
//         {
//             throw new ArgumentException(
//                 "The ContactExtensionField must be of type Boolean",
//                 nameof(contactExtensionField));
//         }
//
//         var success = bool.TryParse(contactExtensionField.Value, out var valueHolder);
//
//         if (!success)
//         {
//             throw new ArgumentException(
//                 "The ContactExtensionField must be of type Boolean",
//                 nameof(contactExtensionField));
//         }
//
//         Id = contactExtensionField.Id;
//         Name = contactExtensionField.Name;
//         Value = valueHolder;
//         TenantId = contactExtensionField.TenantId;
//     }
// }
