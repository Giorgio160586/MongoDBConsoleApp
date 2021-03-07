﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;

namespace MongoDBConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new MongoDBTest();

            Console.ReadLine();
        }
    }
    public class ProdottiModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Codice { get; set; }
        public string Articolo { get; set; }
        public string UM { get; set; }
        public FamigliaModel Famiglia { get; set; }
    }
    public class FamigliaModel
    {
       public string Nome { get; set; }
       public SettoreModel Settore { get; set; }
    }
    public class SettoreModel
    {
        public string Nome { get; set; }
    }
    public class MongoDBTest
    {
        public MongoDBTest()
        {
            var client = new MongoClient();
            IMongoDatabase db = client.GetDatabase("pmgmt");

            var l = db.GetCollection<ProdottiModel>("prodotti");

            //eseguo test di inserimento
            //l.InsertOne(new ProdottiModel()
            //{
            //    Codice = "0011494.01",
            //    Articolo = "LATTE DI CAPRA P/S UHT - LT - 1",
            //    UM = "LT"
            //});


            // eseguo secondo test di inserimento
            //l.InsertOne(new ProdottiModel()
            //{
            //    Codice = "0802720.01",
            //    Articolo = "PARMALAT YOG.0.1% MAGRO CR.FRUTTA - GR - 125 X 8",
            //    UM = "GR",
            //    Famiglia = new FamigliaModel() { Nome = "YOGHURT" }
            //});

            //l.InsertOne(new ProdottiModel()
            //{
            //    Codice = "0582992.01",
            //    Articolo = "YOG.NATURALE INTERO - GR - 125 X 2",
            //    UM = "GR",
            //    Famiglia = new FamigliaModel() { Nome = "YOGHURT" }
            //});

            //l.InsertOne(new ProdottiModel()
            //{
            //    Codice = "0844388.01",
            //    Articolo = "BERETTA WUB.LEERD. - GR - 250 X 3",
            //    UM = "GR",
            //    Famiglia = new FamigliaModel() { Nome = "WURSTEL" }
            //});

            // leggi tutti i prodotti
            var lProdotti = l.Find(new BsonDocument()).ToList();

            // cerca i prodotti della famiglia YOGHURT
            //var filtroYoghurt = Builders<ProdottiModel>.Filter.Where(f => f.Famiglia != null && f.Famiglia.Nome == "YOGHURT");
            //var lProdottiYoghurt = l.Find(filtroYoghurt).ToList();

            // aggiorna aggiungendo il settore
            //foreach (var item in lProdottiYoghurt)
            //{
            //    var filtroID = Builders<ProdottiModel>.Filter.Eq(s => s.Id, item.Id);
            //    item.Famiglia.Settore = new SettoreModel() { Nome = "Ultra freschi" };
            //    l.ReplaceOne(filtroID, item);
            //}
        }
    }
}
