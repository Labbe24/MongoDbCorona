﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDbCoronaTest.Models;
using MongoDbCoronaTest.Services;

namespace MongoDbCoronaTest
{
    class Program
    {
        
        #region Citizens
        public static readonly Citizen[] Citizens =
        {
            new Citizen(1, "Henrik", "Hansen", "201209-9154", 11, "either"),
            new Citizen(2, "Lene", "Mortensen", "230735-2189", 85, "female"),
            new Citizen(3, "Hans", "Larsen", "100282-0686", 38, "female"),
            new Citizen(4, "Hans", "Mortensen", "200503-1945", 17, "female"),
            new Citizen(5, "Lise", "Frederiksen", "151006-5513", 14, "either"),
            new Citizen(6, "Hans", "Olsen", "020637-9743", 83, "female"),
            new Citizen(7, "Mette", "Hansen", "250273-3438", 47, "female"),
            new Citizen(8, "Morten", "Olsen", "160819-2120", 1, "male"),
            new Citizen(9, "Bob", "Mortensen", "180920-7789", 0, "either"),
            new Citizen(10, "Lene", "Olsen", "210991-9650", 29, "either"),
            new Citizen(11, "Alice", "Frederiksen", "180292-3819", 28, "male"),
            new Citizen(12, "Alice", "Jensen", "071140-6096", 80, "either"),
            new Citizen(13, "Alice", "Olsen", "040522-4917", 98, "female"),
            new Citizen(14, "Hanne", "Olsen", "210377-8834", 43, "either"),
            new Citizen(15, "Mette", "Olsen", "140505-8822", 15, "female"),
            new Citizen(16, "Bob", "Larsen", "161029-0902", 91, "either"),
            new Citizen(17, "Morten", "Jensen", "250382-2831", 38, "female"),
            new Citizen(18, "Jens", "Mortensen", "100662-6508", 58, "female"),
            new Citizen(19, "Mathias", "Frederiksen", "260633-8511", 87, "either"),
            new Citizen(20, "Hanne", "Mortensen", "140944-8894", 76, "male"),
            new Citizen(21, "Alice", "Olsen", "150563-4848", 57, "female"),
            new Citizen(22, "Jens", "Mortensen", "010833-4669", 87, "female"),
            new Citizen(23, "Hanne", "Larsen", "260306-1597", 14, "male"),
            new Citizen(24, "Jens", "Larsen", "100354-5700", 66, "female"),
            new Citizen(25, "Lene", "Mortensen", "130581-6589", 39, "male"),
            new Citizen(26, "Henrik", "Jensen", "030239-2849", 81, "female"),
            new Citizen(27, "Jens", "Frederiksen", "260533-9722", 87, "either"),
            new Citizen(28, "Mette", "Hansen", "140964-3558", 56, "male"),
            new Citizen(29, "Alice", "Hansen", "051103-4086", 17, "either"),
            new Citizen(30, "Jens", "Olsen", "061062-6328", 58, "male"),
            new Citizen(31, "Mette", "Mortensen", "021137-0508", 83, "female"),
            new Citizen(32, "Hans", "Hansen", "240877-0805", 43, "either"),
            new Citizen(33, "Mathias", "Larsen", "190426-6611", 94, "either"),
            new Citizen(34, "Henrik", "Hansen", "081130-0002", 90, "male"),
            new Citizen(35, "Morten", "Mortensen", "170551-0100", 69, "female"),
            new Citizen(36, "Alice", "Jensen", "240477-4467", 43, "either"),
            new Citizen(37, "Lise", "Hansen", "090490-6312", 30, "either"),
            new Citizen(38, "Mathias", "Mortensen", "151266-4158", 54, "male"),
            new Citizen(39, "Alice", "Frederiksen", "280139-6939", 81, "either"),
            new Citizen(40, "Alice", "Mortensen", "080193-9200", 27, "either"),
            new Citizen(41, "Mette", "Hansen", "280340-2357", 80, "male"),
            new Citizen(42, "Lise", "Larsen", "160527-9487", 93, "male"),
            new Citizen(43, "Lise", "Mortensen", "110813-0713", 7, "female"),
            new Citizen(44, "Mette", "Frederiksen", "081035-4520", 85, "male"),
            new Citizen(45, "Bob", "Hansen", "080915-7389", 5, "female"),
            new Citizen(46, "Bob", "Hansen", "220370-4840", 50, "either"),
            new Citizen(47, "Hanne", "Jensen", "200975-6615", 45, "either"),
            new Citizen(48, "Lise", "Mortensen", "141131-0659", 89, "female"),
            new Citizen(49, "Jesper", "Larsen", "131046-3640", 74, "either"),
            new Citizen(50, "Lise", "Mortensen", "190391-3178", 29, "either"),
            new Citizen(51, "Alice", "Olsen", "120859-8434", 61, "male"),
            new Citizen(52, "Alice", "Frederiksen", "011063-7581", 57, "male"),
            new Citizen(53, "Mathias", "Frederiksen", "250942-2588", 78, "female"),
            new Citizen(54, "Henrik", "Frederiksen", "120291-8868", 29, "either"),
            new Citizen(55, "Lene", "Hansen", "150518-3294", 2, "female"),
            new Citizen(56, "Henrik", "Mortensen", "080314-8040", 6, "female"),
            new Citizen(57, "Henrik", "Mortensen", "280875-4848", 45, "female"),
            new Citizen(58, "Lene", "Frederiksen", "160141-3010", 79, "male"),
            new Citizen(59, "Mette", "Frederiksen", "141219-7378", 1, "female"),
            new Citizen(60, "Lene", "Jensen", "130673-2333", 47, "male"),
            new Citizen(61, "Henrik", "Larsen", "130660-0632", 60, "either"),
            new Citizen(62, "Jesper", "Mortensen", "150580-9963", 40, "either"),
            new Citizen(63, "Jesper", "Mortensen", "080121-5419", 99, "female"),
            new Citizen(64, "Hanne", "Larsen", "080141-4287", 79, "female"),
            new Citizen(65, "Jesper", "Mortensen", "050466-5745", 54, "either"),
            new Citizen(66, "Hanne", "Frederiksen", "170312-3999", 8, "female"),
            new Citizen(67, "Henrik", "Olsen", "160925-4371", 95, "male"),
            new Citizen(68, "Bob", "Jensen", "120904-3356", 16, "male"),
            new Citizen(69, "Lise", "Frederiksen", "110802-9350", 18, "either"),
            new Citizen(70, "Lise", "Larsen", "050687-4750", 33, "either"),
            new Citizen(71, "Lise", "Hansen", "230252-6329", 68, "either"),
            new Citizen(72, "Alice", "Olsen", "101249-7038", 71, "either"),
            new Citizen(73, "Jesper", "Mortensen", "160343-8991", 77, "male"),
            new Citizen(74, "Jens", "Olsen", "170699-2395", 21, "either"),
            new Citizen(75, "Bob", "Frederiksen", "091280-7353", 40, "male"),
            new Citizen(76, "Jesper", "Mortensen", "160960-4286", 60, "male"),
            new Citizen(77, "Jesper", "Larsen", "190314-6674", 6, "male"),
            new Citizen(78, "Morten", "Olsen", "060761-7447", 59, "male"),
            new Citizen(79, "Mette", "Hansen", "190502-8797", 18, "male"),
            new Citizen(80, "Mette", "Jensen", "011220-0166", 0, "female"),
            new Citizen(81, "Lise", "Larsen", "160619-8717", 1, "female"),
            new Citizen(82, "Mathias", "Olsen", "070724-2622", 96, "female"),
            new Citizen(83, "Jesper", "Hansen", "111207-6379", 13, "either"),
            new Citizen(84, "Bob", "Hansen", "090733-5712", 87, "male"),
            new Citizen(85, "Lene", "Jensen", "080859-4024", 61, "female"),
            new Citizen(86, "Bob", "Olsen", "031156-2270", 64, "male"),
            new Citizen(87, "Bob", "Jensen", "230876-3875", 44, "female"),
            new Citizen(88, "Henrik", "Olsen", "280556-3992", 64, "either"),
            new Citizen(89, "Lise", "Frederiksen", "260498-6785", 22, "female"),
            new Citizen(90, "Jesper", "Hansen", "261123-7154", 97, "male"),
            new Citizen(91, "Mette", "Jensen", "040592-9658", 28, "male"),
            new Citizen(92, "Lene", "Jensen", "270372-5739", 48, "male"),
            new Citizen(93, "Mette", "Jensen", "080192-6842", 28, "either"),
            new Citizen(94, "Mette", "Olsen", "170702-3222", 18, "male"),
            new Citizen(95, "Henrik", "Larsen", "220931-5049", 89, "male"),
            new Citizen(96, "Jesper", "Olsen", "280634-1809", 86, "male"),
            new Citizen(97, "Bob", "Frederiksen", "040221-5872", 99, "either"),
            new Citizen(98, "Lise", "Olsen", "240156-0145", 64, "either"),
            new Citizen(99, "Hanne", "Hansen", "250866-4855", 54, "female"),
            new Citizen(100, "Morten", "Larsen", "150103-4148", 17, "male"),
        };
        #endregion

        #region Municipalities

        public static readonly Municipality[] Municipalities =
        {
            new Municipality(101, "København", 632340,9),
            new Municipality(147, "Frederiksberg", 104305,10),
            new Municipality(151, "Ballerup", 48602),
            new Municipality(153, "Brøndby", 35090),
            new Municipality(155, "Dragør", 14494),
            new Municipality(157, "Gentofte", 74830,16),
            new Municipality(159, "Gladsaxe", 69262),
            new Municipality(161, "Glostrup", 23128),
            new Municipality(163, "Herlev", 28953),
            new Municipality(165, "Albertslund", 27731),
            new Municipality(167, "Hvidovre", 53527),
            new Municipality(169, "Høje-Taastrup", 50759),
            new Municipality(173, "Lyngby-Taarbæk", 56214),
            new Municipality(175, "Rødovre", 40652),
            new Municipality(183, "Ishøj", 22989),
            new Municipality(185, "Tårnby", 42989),
            new Municipality(187, "Vallensbæk", 16633),
            new Municipality(190, "Furesø", 40965),
            new Municipality(201, "Allerød", 25633),
            new Municipality(210, "Fredensborg", 40865),
            new Municipality(217, "Helsingør", 62695),
            new Municipality(219, "Hillerød", 51183,15),
            new Municipality(223, "Hørsholm", 24864),
            new Municipality(230, "Rudersdal", 56728),
            new Municipality(240, "Egedal", 43354),
            new Municipality(250, "Frederikssund", 45223),
            new Municipality(253, "Greve", 50558),
            new Municipality(259, "Køge", 60979),
            new Municipality(260, "Halsnæs", 31384),
            new Municipality(265, "Roskilde", 87914,12),
            new Municipality(269, "Solrød", 23255),
            new Municipality(270, "Gribskov", 41048),
            new Municipality(306, "Odsherred", 32957),
            new Municipality(316, "Holbæk", 71541),
            new Municipality(320, "Faxe", 36576),
            new Municipality(326, "Kalundborg", 48436),
            new Municipality(329, "Ringsted", 34852),
            new Municipality(330, "Slagelse", 79073),
            new Municipality(336, "Stevns", 22805),
            new Municipality(340, "Sorø", 29881,13),
            new Municipality(350, "Lejre", 27996),
            new Municipality(360, "Lolland", 41105),
            new Municipality(370, "Næstved", 83143),
            new Municipality(376, "Guldborgsund", 60722),
            new Municipality(390, "Vordingborg", 45566),
            new Municipality(400, "Bornholm", 39499),
            new Municipality(410, "Middelfart", 38853),
            new Municipality(411, "Christiansø", 84000),
            new Municipality(420, "Assens", 40965),
            new Municipality(430, "Faaborg-Midtfyn", 51556),
            new Municipality(440, "Kerteminde", 23812),
            new Municipality(450, "Nyborg", 32008),
            new Municipality(461, "Odense", 204895,8),
            new Municipality(479, "Svendborg", 58296),
            new Municipality(480, "Nordfyns", 29665),
            new Municipality(482, "Langeland", 12491),
            new Municipality(492, "Ærø", 5964,18),
            new Municipality(510, "Haderslev", 55670),
            new Municipality(530, "Billund", 26608),
            new Municipality(540, "Sønderborg", 74220,14),
            new Municipality(550, "Tønder", 37366,6),
            new Municipality(561, "Esbjerg", 115483),
            new Municipality(563, "Fanø", 3488),
            new Municipality(573, "Varde", 49961),
            new Municipality(575, "Vejen", 42742),
            new Municipality(580, "Aabenraa", 58761),
            new Municipality(607, "Fredericia", 51377),
            new Municipality(615, "Horsens", 90966),
            new Municipality(621, "Kolding", 93175),
            new Municipality(630, "Vejle", 115748,1),
            new Municipality(657, "Herning", 89127),
            new Municipality(661, "Holstebro", 58591),
            new Municipality(665, "Lemvig", 19722),
            new Municipality(671, "Struer", 21036),
            new Municipality(706, "Syddjurs", 42962),
            new Municipality(707, "Norddjurs", 37089),
            new Municipality(710, "Favrskov", 48397),
            new Municipality(727, "Odder", 22844),
            new Municipality(730, "Randers", 97805,17),
            new Municipality(740, "Silkeborg", 94026),
            new Municipality(741, "Samsø", 3657),
            new Municipality(746, "Skanderborg", 62678,7),
            new Municipality(751, "Aarhus", 349983,2),
            new Municipality(756, "Ikast-Brande", 41369,3),
            new Municipality(760, "Ringkøbing-Skjern", 56594),
            new Municipality(766, "Hedensted", 46722,5),
            new Municipality(773, "Morsø", 20247),
            new Municipality(779, "Skive", 45851),
            new Municipality(787, "Thisted", 43423),
            new Municipality(791, "Viborg", 96921),
            new Municipality(810, "Brønderslev", 36304),
            new Municipality(813, "Frederikshavn", 59654,11),
            new Municipality(820, "Vesthimmerlands", 36727),
            new Municipality(825, "Læsø", 1786),
            new Municipality(840, "Rebild", 30113),
            new Municipality(846, "Mariagerfjord", 41800),
            new Municipality(849, "Jammerbugt", 38324),
            new Municipality(851, "Aalborg", 217075,4),
            new Municipality(860, "Hjørring", 64483)
        };
        #endregion

        #region Locations

        public static readonly Location[] Locations =
        {
            new Location(1, "Christian Winthersvej 1", 7100),
            new Location(2, "Mejlgade 42", 8000),
            new Location(3, "Finnlandsgade 75", 8001),
            new Location(4, "Gaden 24", 9100),
            new Location(5, "Hvedelunden 37", 7822),
            new Location(6, "Strucksalle 99", 6270),
            new Location(7, "Adelgade 86", 8660),
            new Location(8, "Nyborgvej 422", 5000),
            new Location(9, "Jagtvej 223", 2200),
            new Location(10, "H.C. Boulevard 3", 2201),
            new Location(11, "Barfredsvej 83", 9900),
            new Location(12,"Stormgade 48", 6700),
            new Location(13,"Smedegade 13", 7400),
            new Location(14, "Byrum Hovedgade 56", 9940),
            new Location(15, "Søndergade 12", 8700),
            new Location(16, "Østergade 34", 6000),
            new Location(17, "Mokaivej 43", 8900),
            new Location(18,"Schweiserpladsen 1", 4200)

        };
        #endregion

        #region TestCenters
        public static readonly TestCenter[] TestCenters =
        {
            new TestCenter(1, 10, 12345678, "test@center1.com"),
            new TestCenter(2, 10, 12345678, "test@center2.com"),
            new TestCenter(3, 10, 12345678, "test@center3.com"),
            new TestCenter(4, 10, 12345678, "test@center4.com"),
            new TestCenter(5, 10, 12345678, "test@center5.com"),
            new TestCenter(6, 10, 12345678, "test@center6.com"),
            new TestCenter(7, 10, 12345678, "test@center7.com"),
            new TestCenter(8, 10, 12345678, "test@center8.com"),
            new TestCenter(9, 10, 12345678, "test@center9.com"),
            new TestCenter(10, 10, 12345678, "test@center10.com"),
            new TestCenter(11, 10, 12345678, "test@center11.com"),
            new TestCenter(12, 10, 12345678, "test@center12.com"),
            new TestCenter(13, 10, 12345678, "test@center13.com"),
            new TestCenter(14, 10, 12345678, "test@center14.com"),
            new TestCenter(15, 10, 12345678, "test@center15.com"),
            new TestCenter(16, 10, 12345678, "test@center16.com"),
            new TestCenter(17, 10, 12345678, "test@center17.com"),
            new TestCenter(18, 10, 12345678, "test@center18.com"),
            new TestCenter(19, 10, 12345678, "test@center19.com"),
            new TestCenter(20, 10, 12345678, "test@center20.com"),
            new TestCenter(21, 10, 12345678, "test@center21.com"),
            new TestCenter(22, 10, 12345678, "test@center22.com"),
            new TestCenter(23, 10, 12345678, "test@center23.com"),
            new TestCenter(24, 10, 12345678, "test@center24.com"),
            new TestCenter(25, 10, 12345678, "test@center25.com"),
            new TestCenter(26, 10, 12345678, "test@center26.com"),
            new TestCenter(27, 10, 12345678, "test@center27.com"),
            new TestCenter(28, 10, 12345678, "test@center28.com"),
            new TestCenter(29, 10, 12345678, "test@center29.com"),
            new TestCenter(30, 10, 12345678, "test@center30.com"),
            new TestCenter(31, 10, 12345678, "test@center31.com"),
            new TestCenter(32, 10, 12345678, "test@center32.com"),
            new TestCenter(33, 10, 12345678, "test@center33.com"),
            new TestCenter(34, 10, 12345678, "test@center34.com"),
            new TestCenter(35, 10, 12345678, "test@center35.com"),
            new TestCenter(36, 10, 12345678, "test@center36.com"),
            new TestCenter(37, 10, 12345678, "test@center37.com"),
            new TestCenter(38, 10, 12345678, "test@center38.com"),
            new TestCenter(39, 10, 12345678, "test@center39.com"),
            new TestCenter(40, 10, 12345678, "test@center40.com"),
            new TestCenter(41, 10, 12345678, "test@center41.com"),
            new TestCenter(42, 10, 12345678, "test@center42.com"),
            new TestCenter(43, 10, 12345678, "test@center43.com"),
            new TestCenter(44, 10, 12345678, "test@center44.com"),
            new TestCenter(45, 10, 12345678, "test@center45.com"),
            new TestCenter(46, 10, 12345678, "test@center46.com"),
            new TestCenter(47, 10, 12345678, "test@center47.com"),
            new TestCenter(48, 10, 12345678, "test@center48.com"),
            new TestCenter(49, 10, 12345678, "test@center49.com"),
            new TestCenter(50, 10, 12345678, "test@center50.com"),
            new TestCenter(51, 10, 12345678, "test@center51.com"),
            new TestCenter(52, 10, 12345678, "test@center52.com"),
            new TestCenter(53, 10, 12345678, "test@center53.com"),
            new TestCenter(54, 10, 12345678, "test@center54.com"),
            new TestCenter(55, 10, 12345678, "test@center55.com"),
            new TestCenter(56, 10, 12345678, "test@center56.com"),
            new TestCenter(57, 10, 12345678, "test@center57.com"),
            new TestCenter(58, 10, 12345678, "test@center58.com"),
            new TestCenter(59, 10, 12345678, "test@center59.com"),
            new TestCenter(60, 10, 12345678, "test@center60.com"),
            new TestCenter(61, 10, 12345678, "test@center61.com"),
            new TestCenter(62, 10, 12345678, "test@center62.com"),
            new TestCenter(63, 10, 12345678, "test@center63.com"),
            new TestCenter(64, 10, 12345678, "test@center64.com"),
            new TestCenter(65, 10, 12345678, "test@center65.com"),
            new TestCenter(66, 10, 12345678, "test@center66.com"),
            new TestCenter(67, 10, 12345678, "test@center67.com"),
            new TestCenter(68, 10, 12345678, "test@center68.com"),
            new TestCenter(69, 10, 12345678, "test@center69.com"),
            new TestCenter(70, 10, 12345678, "test@center70.com"),
            new TestCenter(71, 10, 12345678, "test@center71.com"),
            new TestCenter(72, 10, 12345678, "test@center72.com"),
            new TestCenter(73, 10, 12345678, "test@center73.com"),
            new TestCenter(74, 10, 12345678, "test@center74.com"),
            new TestCenter(75, 10, 12345678, "test@center75.com"),
            new TestCenter(76, 10, 12345678, "test@center76.com"),
            new TestCenter(77, 10, 12345678, "test@center77.com"),
            new TestCenter(78, 10, 12345678, "test@center78.com"),
            new TestCenter(79, 10, 12345678, "test@center79.com"),
            new TestCenter(80, 10, 12345678, "test@center80.com"),
            new TestCenter(81, 10, 12345678, "test@center81.com"),
            new TestCenter(82, 10, 12345678, "test@center82.com"),
            new TestCenter(83, 10, 12345678, "test@center83.com"),
            new TestCenter(84, 10, 12345678, "test@center84.com"),
            new TestCenter(85, 10, 12345678, "test@center85.com"),
            new TestCenter(86, 10, 12345678, "test@center86.com"),
            new TestCenter(87, 10, 12345678, "test@center87.com"),
            new TestCenter(88, 10, 12345678, "test@center88.com"),
            new TestCenter(89, 10, 12345678, "test@center89.com"),
            new TestCenter(90, 10, 12345678, "test@center90.com"),
            new TestCenter(91, 10, 12345678, "test@center91.com"),
            new TestCenter(92, 10, 12345678, "test@center92.com"),
            new TestCenter(93, 10, 12345678, "test@center93.com"),
            new TestCenter(94, 10, 12345678, "test@center94.com"),
            new TestCenter(95, 10, 12345678, "test@center95.com"),
            new TestCenter(96, 10, 12345678, "test@center96.com"),
            new TestCenter(97, 10, 12345678, "test@center97.com"),
            new TestCenter(98, 10, 12345678, "test@center98.com"),
            new TestCenter(99, 10, 12345678, "test@center99.com")
        };

        #endregion


        

        public static DbClient Client = new DbClient(new MongoClient());

        static void Main(string[] args)
        {
            DbClient client = new DbClient(new MongoClient());
            var citizenService = new CitizenService(Client);
            var municipalityService = new MunicipalityService(Client);
            var locationService = new LocationService(Client, municipalityService);
            var testCenterService = new TestCenterService(Client);
            var testService = new TestService(Client);

            bool run = true;
            while (run)
            {
                Console.WriteLine("[A] Add new Citizen");
                Console.WriteLine("[B] Add new TestCenter and TestCenterManagement");
                Console.WriteLine("[C] Add new Test");
                Console.WriteLine("[D] Add Test to all Citizens");
                Console.WriteLine("[E] Add new Location");
                Console.WriteLine("[F] Add Locations to all Citizens");
                Console.WriteLine("[G] Seed data");
                Console.WriteLine("[H] View active cases for Municipalities");
                Console.WriteLine("[I] View active cases by Sex");
                Console.WriteLine("[J] View active cases by Age");
                Console.WriteLine("[K] View possible cases by Location three days prior");
                Console.WriteLine("[X] Quit");
                Console.WriteLine("INPUT: ");

                var userInput = Console.ReadKey();

                switch (userInput.KeyChar)
                {
                    case 'A':
                    {
                        Console.Write("Firstname: ");
                        string firstname = Console.ReadLine();
                        Console.Write("Lastname: ");
                        string lastname = Console.ReadLine();
                        Console.Write("SSN (XXXXXX-XXXX): ");
                        string ssn = Console.ReadLine();
                        Console.Write("Age: ");
                        string age = Console.ReadLine();
                        Console.Write("Sex: ");
                        string sex = Console.ReadLine();
                        Console.Write("Municipality: ");
                        string municipalityName = Console.ReadLine();

                        int municipalityId = municipalityService.GetId(municipalityName);

                        var newCitizen = new Citizen
                        {
                            Firstname = firstname,
                            Lastname = lastname,
                            SSN = ssn,
                            Age = int.Parse(age),
                            Sex = sex,
                            Tests = new List<Test>(),
                            Location_id = new List<int>(),
                            Municipality_id = municipalityId
                        };

                        citizenService.AddCitizen(newCitizen);
                    }
                        break;

                    case 'B':
                    {
                        Console.Write("Municipality: ");
                        string municipalityName = Console.ReadLine();
                        Console.Write("Hours: ");
                        int hours = int.Parse(Console.ReadLine());
                        Console.Write("Phonenumber: ");
                        int phonenumber = int.Parse(Console.ReadLine());
                        Console.Write("Email: ");
                        string email = Console.ReadLine();

                        testCenterService.AddTestCenter(municipalityName, hours, phonenumber, email);
                    }
                        break;

                    case 'C':
                    {
                        Console.Write("Citizen-ID: ");
                        int citizenId = int.Parse(Console.ReadLine());
                        Console.Write("TestCenter-ID: ");
                        int testCenterId = int.Parse(Console.ReadLine());

                        if (Client.TestCenters.Find(t => t.TestCenterId == testCenterId).Any())
                        {
                            Console.WriteLine("No TestCenter with ID {0} exists.", testCenterId);
                            break;
                        }
                        else if (Client.Citizens.Find(c => c.CitizenId == citizenId).Any())
                        {
                            Console.WriteLine("No Citizen with ID {0} exists.", citizenId);
                            break;
                        }

                        testService.TestCitizen(citizenId, testCenterId);
                    }
                        break;

                    case 'D':
                    {
                        testService.TestAllCitizens();
                        Console.WriteLine("All citizens tested.");
                    }
                        break;

                    case 'E':
                    {
                        Console.Write("Citizen-ID: ");
                        int citizenId = int.Parse(Console.ReadLine());
                        Console.Write("Address: ");
                        string address = Console.ReadLine();
                        Console.Write("Zip: ");
                        int zip = int.Parse(Console.ReadLine());
                        Console.Write("Municipality name: ");
                        string municipalityName = Console.ReadLine();

                        locationService.AddLocation(citizenId, address, zip, municipalityName);
                    }
                        break;

                    case 'F':
                    {
                        locationService.AddLocationToAllCitizen();
                        Console.WriteLine("All Citizen have now locations");
                    }
                        break;

                    case 'G':
                    {
                        Console.WriteLine("Sure you want to seed? Seeding will reset all Citizens and Municipalities[Y/N]");
                        string userKey = Console.ReadLine();

                        if (userKey.Contains('Y'))
                        {
                            Seed();
                            Console.WriteLine("Seeding done!");
                        }
                        else Console.WriteLine("Seeding canceled.");
                    }
                        break;

                    case 'H':
                    {
                        testCenterService.ActiveCovidCasesPerMunicipality();
                    }
                        break;

                    case 'I':
                    {
                        testCenterService.ActiveCovidCasesSex();
                    }
                        break;

                    case 'J':
                    {
                        Console.Write("Min age: ");
                        int minAge = int.Parse(Console.ReadLine());
                        Console.Write("Max age: ");
                        int maxAge = int.Parse(Console.ReadLine());
                        int cases = testCenterService.ActiveCovidCasesAge(minAge, maxAge);
                        Console.WriteLine("Total number of cases: {0}", cases);
                    }
                        break;

                    case 'K':
                    {
                        Console.Write("Infected citizen's ID: ");
                        int citizenId = int.Parse(Console.ReadLine());
                        List<Citizen> citizens = citizenService.CitizensAtSameLocation(citizenId);
                        Console.WriteLine("Citizens which has been the at the same location as an infected: ");
                        foreach (var citizen in citizens)
                        {
                            Console.WriteLine("-------------------------------------------------------");
                            Console.WriteLine($"ID: {citizen.CitizenId}");
                            Console.WriteLine($"Name: {citizen.Firstname} {citizen.Lastname}");
                            Console.WriteLine($"SSN : {citizen.SSN}");
                            Console.WriteLine("-------------------------------------------------------");
                        }
                    }
                        break;

                    case 'X':
                        run = false;
                        break;

                }

                Console.WriteLine("\nPress any key.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        #region MongoMethods

        public static void Seed()
        {
            /*--!Delete Collections*/
            Client.Citizens.DeleteMany(_ => true);
            Client.Municipalities.DeleteMany(_ => true);
            Client.Locations.DeleteMany(_ => true);
            Client.TestCenters.DeleteMany(_ => true);

            /*--!Seed Citizens*/
            Client.Citizens.InsertMany(Citizens);

            /*--!Seed Municipalities*/
            Client.Municipalities.InsertMany(Municipalities);

            /*--!Seed TestCenters*/
            Client.TestCenters.InsertMany(TestCenters);

            /*--!Seed Municipalities with Citizens*/
            var rand = new Random();
            List<Municipality> municipalities = new List<Municipality>();

            foreach (var municipality in Municipalities)
            {
                municipalities.Add(municipality);
            }

            foreach (var citizen in Citizens)
            {
                int index = rand.Next(municipalities.Count());
                var updatedCitizen = Client.Citizens.FindOneAndDelete(c => c.CitizenId == citizen.CitizenId);
                updatedCitizen.Municipality_id = municipalities[index].MunicipalityId;
                Client.Citizens.InsertOne(updatedCitizen);
            }

            Client.Locations.InsertMany(Locations);
        }

        #endregion
    }
}
