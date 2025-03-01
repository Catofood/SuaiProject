using System.Text.Json.Serialization;

namespace Application.GuapRaspApiClient.DTO;

public class Group()
{
    [JsonPropertyName("Name")] public string Name;
    [JsonPropertyName("ItemId")] public int ItemId;
}


// Пример:
//
// [
//     {
//         "Name": "8114Кв",
//         "ItemId": 1
//     },
//     {
//         "Name": "В1441",
//         "ItemId": 2
//     },
// ]