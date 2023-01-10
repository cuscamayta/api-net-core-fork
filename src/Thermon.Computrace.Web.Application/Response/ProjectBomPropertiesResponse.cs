using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thermon.Computrace.Web.Application.Response
{
    public class ProjectBomPropertiesResponse
    {
        public List<CircuitsDto> Circuits { get; set; }
    }

    public class CircuitsDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<SegmentsDto> Segments { get; set; }
    }

    public class SegmentsDto
    {
        public string CircuitId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        //public List<ItemsDto> Items { get; set; }

        public SegmentsDto()
        {

        }

        public SegmentsDto(string circuitId, string id, string name)
        {
            CircuitId = circuitId;
            Name = name;
            Id = id;

        }
    }

    public class ItemsDto
    {
        public string SegmentId { get; set; }
        public string Id { get; set; }
        public string ShortDescription { get; set; }
        public string CatalogNumber { get; set; }
        public int Quantity { get; set; }
        public string Parts { get; set; }
        public string Units { get; set; }

        public ItemsDto(string segmentId, string id, string description, string catalogNumnber, int quantity, string parts, string units)
        {
            SegmentId = segmentId;
            Id = id;
            ShortDescription = description;
            CatalogNumber = catalogNumnber;
            Quantity = quantity;
            Parts = parts;
            Units = units;
        }

        public ItemsDto()
        {

        }
    }

    public class Materials
    {
        public int ItemNumber { get; set; }
        public string PartNumber { get; set; }
        public string CatalogNumber { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public string Units { get; set; }
    }

    public static class CircuitsData
    {
        public static List<CircuitsDto> Circuits = new List<CircuitsDto>() {
            new CircuitsDto(){
             Id = "e58083ac-7e49-4744-b27d-879485d46359",
             Name = "Circuit 001",
             Segments = new List<SegmentsDto>(){
                new SegmentsDto("e58083ac-7e49-4744-b27d-879485d46359","aa59213c-2842-42bc-a231-2f972462a2f9","Segment1 001"),
                new SegmentsDto("e58083ac-7e49-4744-b27d-879485d46359","6dc7af9c-ba3a-4b74-8e12-352a543b54f9","Segment1 002"),
                new SegmentsDto("e58083ac-7e49-4744-b27d-879485d46359","c239612c-92d4-4f70-ad63-0c7ea780815c","Segment1 003"),
                new SegmentsDto("e58083ac-7e49-4744-b27d-879485d46359","efd9764f-11e8-4518-9699-41b31f2136aa","Segment1 004"),
                new SegmentsDto("e58083ac-7e49-4744-b27d-879485d46359","ea6c7b8b-f373-493f-a8e5-de33a45337d9","Segment1 005"),
             }
            },
            new CircuitsDto(){
             Id = "b20b7282-6822-4e69-be24-da9459439d44",
             Name = "Circuit 002",
             Segments = new List<SegmentsDto>(){
                new SegmentsDto("b20b7282-6822-4e69-be24-da9459439d44","27c1a07a-ef92-419c-875e-4e317245101b","Segment2 001"),
                new SegmentsDto("b20b7282-6822-4e69-be24-da9459439d44","828a3df1-045f-4fb5-bd74-c6200af68569","Segment2 002"),
                new SegmentsDto("b20b7282-6822-4e69-be24-da9459439d44","0f001ef8-40a3-4e8c-a3fe-7d338aa88811","Segment2 003"),
                new SegmentsDto("b20b7282-6822-4e69-be24-da9459439d44","14edde21-6d44-450a-bcf4-a3a7f759c192","Segment2 004"),
                new SegmentsDto("b20b7282-6822-4e69-be24-da9459439d44","857ec424-c45e-4697-a0d5-958b7a9853c0","Segment2 005"),
             }
            },
            new CircuitsDto(){
             Id = "b07389f3-4f22-4ccb-baae-d1c6aaf8adde",
             Name = "Circuit 003",
             Segments= new List<SegmentsDto>(){
                new SegmentsDto("b07389f3-4f22-4ccb-baae-d1c6aaf8adde","87afaa78-7966-4cc2-9de1-37088b1efa4f","Segment3 001"),
                new SegmentsDto("b07389f3-4f22-4ccb-baae-d1c6aaf8adde","ec783810-7416-41ba-a11a-227ad98652cd","Segment3 002"),
                new SegmentsDto("b07389f3-4f22-4ccb-baae-d1c6aaf8adde","ecc69320-7f8c-4ad9-b138-1f218a600ce2","Segment3 003"),
                new SegmentsDto("b07389f3-4f22-4ccb-baae-d1c6aaf8adde","cb69753d-c685-47ee-8234-0a1666fce671","Segment3 004"),
                new SegmentsDto("b07389f3-4f22-4ccb-baae-d1c6aaf8adde","b5262ab0-4aab-4283-8c63-97873bbedc64","Segment3 005"),
             }
            },
            new CircuitsDto(){
             Id = "152a0e5c-5ec4-4e5d-88f0-0171a773e486",
             Name = "Circuit 004",
             Segments= new List<SegmentsDto>(){
                new SegmentsDto("152a0e5c-5ec4-4e5d-88f0-0171a773e486","709871dc-d048-4faf-81da-0f84cea0e4cb","Segment4 001"),
                new SegmentsDto("152a0e5c-5ec4-4e5d-88f0-0171a773e486","c3cd61d0-d1e8-4e82-9cf3-29316682ea75","Segment4 002"),
                new SegmentsDto("152a0e5c-5ec4-4e5d-88f0-0171a773e486","73c45ae3-a492-4904-bf1b-8f33d634c996","Segment4 003"),
                new SegmentsDto("152a0e5c-5ec4-4e5d-88f0-0171a773e486","0e55e51f-c90f-4f3c-a92d-7721526d8f1d","Segment4 004"),
                new SegmentsDto("152a0e5c-5ec4-4e5d-88f0-0171a773e486","249836a7-cb1c-4384-bfc8-17a41ca3134d","Segment4 005"),
             }
            },
            new CircuitsDto(){
             Id = "c66482ae-3507-4557-b6d7-5c468bce653f",
             Name = "Circuit 005",
             Segments = new List<SegmentsDto>(){
                new SegmentsDto("c66482ae-3507-4557-b6d7-5c468bce653f","2d20cc0e-0784-4799-816d-51c54b77b5cf","Segment5 001"),
                new SegmentsDto("c66482ae-3507-4557-b6d7-5c468bce653f","820ee20f-9170-41e0-bb00-05d6b976eb43","Segment5 002"),
                new SegmentsDto("c66482ae-3507-4557-b6d7-5c468bce653f","a7ed5cd0-3862-499c-bf01-e42332e895fd","Segment5 003"),
                new SegmentsDto("c66482ae-3507-4557-b6d7-5c468bce653f","dbb99edf-3933-4e71-a819-add43c094dd6","Segment5 004"),
                new SegmentsDto("c66482ae-3507-4557-b6d7-5c468bce653f","92f9f8ed-6bc3-46fe-850e-74000306c4e6","Segment5 005"),
             }
            },
            new CircuitsDto(){
             Id = "411bafc8-2e1a-4498-a867-64aa635243cc",
             Name = "Circuit 006",
             Segments= new List<SegmentsDto>(){
                new SegmentsDto("411bafc8-2e1a-4498-a867-64aa635243cc","ebb68d2f-e564-45db-a04e-308888bc2f57","Segment6 001"),
                new SegmentsDto("411bafc8-2e1a-4498-a867-64aa635243cc","f4928b5a-b3d0-4b58-8446-470bb17d2c94","Segment6 002"),
                new SegmentsDto("411bafc8-2e1a-4498-a867-64aa635243cc","4909646e-81cc-4c15-8fd3-8a66821ce894","Segment6 003"),
                new SegmentsDto("411bafc8-2e1a-4498-a867-64aa635243cc","40a5f6fe-b272-4172-ba27-267b319ef531","Segment6 004"),
                new SegmentsDto("411bafc8-2e1a-4498-a867-64aa635243cc","2839eaaf-d3a3-4b0e-b91f-6b2a4e6d5273","Segment6 005")
             }
            },
            new CircuitsDto(){
             Id = "7ca626fb-0387-4c67-99b7-2bc8616fff02",
             Name = "Circuit 007"
            },
            new CircuitsDto(){
             Id = "064e6eca-9fb0-4e39-8e09-536bc43d7f60",
             Name = "Circuit 008"
            },
            new CircuitsDto(){
             Id = "ebc5b832-47a1-4a3c-ba72-b799cc10fe65",
             Name = "Circuit 009"
            },
            new CircuitsDto(){
             Id = "e58083ac-7e49-4744-b27d-879485d46359",
             Name = "Circuit 010"
            }
        };

        public static List<SegmentsDto> Segments = new List<SegmentsDto>() {
            new SegmentsDto("e58083ac-7e49-4744-b27d-879485d46359","aa59213c-2842-42bc-a231-2f972462a2f9","Segment1 001"),
            new SegmentsDto("e58083ac-7e49-4744-b27d-879485d46359","6dc7af9c-ba3a-4b74-8e12-352a543b54f9","Segment1 002"),
            new SegmentsDto("e58083ac-7e49-4744-b27d-879485d46359","c239612c-92d4-4f70-ad63-0c7ea780815c","Segment1 003"),
            new SegmentsDto("e58083ac-7e49-4744-b27d-879485d46359","efd9764f-11e8-4518-9699-41b31f2136aa","Segment1 004"),
            new SegmentsDto("e58083ac-7e49-4744-b27d-879485d46359","ea6c7b8b-f373-493f-a8e5-de33a45337d9","Segment1 005"),

            new SegmentsDto("b20b7282-6822-4e69-be24-da9459439d44","27c1a07a-ef92-419c-875e-4e317245101b","Segment2 001"),
            new SegmentsDto("b20b7282-6822-4e69-be24-da9459439d44","828a3df1-045f-4fb5-bd74-c6200af68569","Segment2 002"),
            new SegmentsDto("b20b7282-6822-4e69-be24-da9459439d44","0f001ef8-40a3-4e8c-a3fe-7d338aa88811","Segment2 003"),
            new SegmentsDto("b20b7282-6822-4e69-be24-da9459439d44","14edde21-6d44-450a-bcf4-a3a7f759c192","Segment2 004"),
            new SegmentsDto("b20b7282-6822-4e69-be24-da9459439d44","857ec424-c45e-4697-a0d5-958b7a9853c0","Segment2 005"),

            new SegmentsDto("b07389f3-4f22-4ccb-baae-d1c6aaf8adde","87afaa78-7966-4cc2-9de1-37088b1efa4f","Segment3 001"),
            new SegmentsDto("b07389f3-4f22-4ccb-baae-d1c6aaf8adde","ec783810-7416-41ba-a11a-227ad98652cd","Segment3 002"),
            new SegmentsDto("b07389f3-4f22-4ccb-baae-d1c6aaf8adde","ecc69320-7f8c-4ad9-b138-1f218a600ce2","Segment3 003"),
            new SegmentsDto("b07389f3-4f22-4ccb-baae-d1c6aaf8adde","cb69753d-c685-47ee-8234-0a1666fce671","Segment3 004"),
            new SegmentsDto("b07389f3-4f22-4ccb-baae-d1c6aaf8adde","b5262ab0-4aab-4283-8c63-97873bbedc64","Segment3 005"),

            new SegmentsDto("152a0e5c-5ec4-4e5d-88f0-0171a773e486","709871dc-d048-4faf-81da-0f84cea0e4cb","Segment4 001"),
            new SegmentsDto("152a0e5c-5ec4-4e5d-88f0-0171a773e486","c3cd61d0-d1e8-4e82-9cf3-29316682ea75","Segment4 002"),
            new SegmentsDto("152a0e5c-5ec4-4e5d-88f0-0171a773e486","73c45ae3-a492-4904-bf1b-8f33d634c996","Segment4 003"),
            new SegmentsDto("152a0e5c-5ec4-4e5d-88f0-0171a773e486","0e55e51f-c90f-4f3c-a92d-7721526d8f1d","Segment4 004"),
            new SegmentsDto("152a0e5c-5ec4-4e5d-88f0-0171a773e486","249836a7-cb1c-4384-bfc8-17a41ca3134d","Segment4 005"),

            new SegmentsDto("c66482ae-3507-4557-b6d7-5c468bce653f","2d20cc0e-0784-4799-816d-51c54b77b5cf","Segment5 001"),
            new SegmentsDto("c66482ae-3507-4557-b6d7-5c468bce653f","820ee20f-9170-41e0-bb00-05d6b976eb43","Segment5 002"),
            new SegmentsDto("c66482ae-3507-4557-b6d7-5c468bce653f","a7ed5cd0-3862-499c-bf01-e42332e895fd","Segment5 003"),
            new SegmentsDto("c66482ae-3507-4557-b6d7-5c468bce653f","dbb99edf-3933-4e71-a819-add43c094dd6","Segment5 004"),
            new SegmentsDto("c66482ae-3507-4557-b6d7-5c468bce653f","92f9f8ed-6bc3-46fe-850e-74000306c4e6","Segment5 005"),

            new SegmentsDto("411bafc8-2e1a-4498-a867-64aa635243cc","ebb68d2f-e564-45db-a04e-308888bc2f57","Segment6 001"),
            new SegmentsDto("411bafc8-2e1a-4498-a867-64aa635243cc","f4928b5a-b3d0-4b58-8446-470bb17d2c94","Segment6 002"),
            new SegmentsDto("411bafc8-2e1a-4498-a867-64aa635243cc","4909646e-81cc-4c15-8fd3-8a66821ce894","Segment6 003"),
            new SegmentsDto("411bafc8-2e1a-4498-a867-64aa635243cc","40a5f6fe-b272-4172-ba27-267b319ef531","Segment6 004"),
            new SegmentsDto("411bafc8-2e1a-4498-a867-64aa635243cc","2839eaaf-d3a3-4b0e-b91f-6b2a4e6d5273","Segment6 005")
        };

        public static List<ItemsDto> Items = new List<ItemsDto>() {
            new ItemsDto("aa59213c-2842-42bc-a231-2f972462a2f9","c1533d04-9481-45db-9590-ad5ccc323716","Circuit Fabrication Kit 001","PETK-1D",2,"23411","EA"),
            new ItemsDto("aa59213c-2842-42bc-a231-2f972462a2f9","f4c4be73-5acb-4632-9bbf-a36edaa3522b","Circuit Fabrication Kit 002","PETK-2D",2,"23411","EA"),
            new ItemsDto("aa59213c-2842-42bc-a231-2f972462a2f9","f153c474-befc-42d0-9067-a4491b4dd3dd","Circuit Fabrication Kit 002","PETK-3D",2,"23411","EA"),

            new ItemsDto("6dc7af9c-ba3a-4b74-8e12-352a543b54f9","6a5888fd-e192-4c66-bcef-fee5ed5031fa","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),
            new ItemsDto("6dc7af9c-ba3a-4b74-8e12-352a543b54f9","a424035a-dfb9-4720-a04f-6367d5eba6b0","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),
            new ItemsDto("6dc7af9c-ba3a-4b74-8e12-352a543b54f9","0578dd34-46f9-4ef9-a92f-1716f19fd5a4","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),

            new ItemsDto("c239612c-92d4-4f70-ad63-0c7ea780815c","19da7647-38f5-444c-86cd-e6d7c433ae2e","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),
            new ItemsDto("c239612c-92d4-4f70-ad63-0c7ea780815c","e71159dc-49a9-4a86-9be8-55e9ce1cc18c","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),
            new ItemsDto("c239612c-92d4-4f70-ad63-0c7ea780815c","c9adc97a-1c90-43da-913a-da10729e9acb","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),

            new ItemsDto("efd9764f-11e8-4518-9699-41b31f2136aa","af42bea4-d1ed-4fa3-b2f8-883e654623e4","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),
            new ItemsDto("efd9764f-11e8-4518-9699-41b31f2136aa","7a359c0b-f851-49a4-9149-a4ff39a0e599","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),
            new ItemsDto("efd9764f-11e8-4518-9699-41b31f2136aa","7beb06c2-e4d8-4cd5-a17a-6af1cd15bfe9","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),

            new ItemsDto("ea6c7b8b-f373-493f-a8e5-de33a45337d9","82d23bdb-91a0-4f05-89b5-e71e2e89d529","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),
            new ItemsDto("ea6c7b8b-f373-493f-a8e5-de33a45337d9","a37ab8d5-1847-4bca-a5da-9b763bb8e6da","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),
            new ItemsDto("ea6c7b8b-f373-493f-a8e5-de33a45337d9","313bb20f-0e6d-4298-823e-5b93b7bf144a","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),

            new ItemsDto("27c1a07a-ef92-419c-875e-4e317245101b","62ef4a34-d231-401c-9438-d1a4ae24aa99","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),
            new ItemsDto("27c1a07a-ef92-419c-875e-4e317245101b","f2ccbe5a-e34f-43a5-b602-6f8b63b9a212","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),
            new ItemsDto("27c1a07a-ef92-419c-875e-4e317245101b","3efcd3ed-b0ce-43b1-9058-5f3f7d870852","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),

            new ItemsDto("828a3df1-045f-4fb5-bd74-c6200af68569","d056386f-cebf-42e5-a25b-2f6b12929f75","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),
            new ItemsDto("828a3df1-045f-4fb5-bd74-c6200af68569","906b249e-5eeb-452e-baa5-877c73edd61d","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),
            new ItemsDto("828a3df1-045f-4fb5-bd74-c6200af68569","749a390d-4775-4232-84ef-1a8861ed8619","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),

            new ItemsDto("0f001ef8-40a3-4e8c-a3fe-7d338aa88811","7dd439a0-c5ba-40a1-ab08-6fa815eb38c8","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),
            new ItemsDto("0f001ef8-40a3-4e8c-a3fe-7d338aa88811","38685511-49cb-4403-b246-209195308fa4","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),
            new ItemsDto("0f001ef8-40a3-4e8c-a3fe-7d338aa88811","7519e2b2-484a-4161-be0e-c9a70f29645e","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),

            new ItemsDto("14edde21-6d44-450a-bcf4-a3a7f759c192","f88aad4c-62b2-4523-8ef1-54dde027cc8d","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),
            new ItemsDto("14edde21-6d44-450a-bcf4-a3a7f759c192","343006f4-ee7a-4529-a141-09fe59faf1d3","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),
            new ItemsDto("14edde21-6d44-450a-bcf4-a3a7f759c192","a763a947-0d01-41d6-9cdc-1ea378625835","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),

            new ItemsDto("857ec424-c45e-4697-a0d5-958b7a9853c0","09c68e1a-94fd-4d09-ad83-dd05c28df2d2","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),
            new ItemsDto("857ec424-c45e-4697-a0d5-958b7a9853c0","452f5f82-4c15-43ec-a755-f8536ab511d5","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),
            new ItemsDto("857ec424-c45e-4697-a0d5-958b7a9853c0","d78355af-5a43-4444-97bb-8268fbc5e216","Circuit Fabrication Kit 002","PETK-1D",2,"23411","EA"),
        };
    }
}
