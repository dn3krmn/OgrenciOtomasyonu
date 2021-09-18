namespace OgrenciYonetimSistemi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bolums",
                c => new
                    {
                        BolumID = c.Int(nullable: false, identity: true),
                        BolumAd = c.String(),
                        FakulteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BolumID)
                .ForeignKey("dbo.Fakultes", t => t.FakulteID)
                .Index(t => t.FakulteID);
            
            CreateTable(
                "dbo.Ders",
                c => new
                    {
                        DersID = c.Int(nullable: false, identity: true),
                        DersAdi = c.String(),
                        BolumID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DersID)
                .ForeignKey("dbo.Bolums", t => t.BolumID)
                .Index(t => t.BolumID);
            
            CreateTable(
                "dbo.OgrenciDers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OgrenciNo = c.Int(nullable: false),
                        DersID = c.Int(nullable: false),
                        Yil = c.String(),
                        Yariyil = c.String(),
                        Vize = c.Int(nullable: false),
                        Final = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ders", t => t.DersID)
                .ForeignKey("dbo.Ogrencis", t => t.OgrenciNo)
                .Index(t => t.OgrenciNo)
                .Index(t => t.DersID);
            
            CreateTable(
                "dbo.Ogrencis",
                c => new
                    {
                        OgrenciNo = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                        BolumID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OgrenciNo)
                .ForeignKey("dbo.Bolums", t => t.BolumID)
                .Index(t => t.BolumID);
            
            CreateTable(
                "dbo.Fakultes",
                c => new
                    {
                        FakulteID = c.Int(nullable: false, identity: true),
                        FakulteAd = c.String(),
                    })
                .PrimaryKey(t => t.FakulteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bolums", "FakulteID", "dbo.Fakultes");
            DropForeignKey("dbo.OgrenciDers", "OgrenciNo", "dbo.Ogrencis");
            DropForeignKey("dbo.Ogrencis", "BolumID", "dbo.Bolums");
            DropForeignKey("dbo.OgrenciDers", "DersID", "dbo.Ders");
            DropForeignKey("dbo.Ders", "BolumID", "dbo.Bolums");
            DropIndex("dbo.Ogrencis", new[] { "BolumID" });
            DropIndex("dbo.OgrenciDers", new[] { "DersID" });
            DropIndex("dbo.OgrenciDers", new[] { "OgrenciNo" });
            DropIndex("dbo.Ders", new[] { "BolumID" });
            DropIndex("dbo.Bolums", new[] { "FakulteID" });
            DropTable("dbo.Fakultes");
            DropTable("dbo.Ogrencis");
            DropTable("dbo.OgrenciDers");
            DropTable("dbo.Ders");
            DropTable("dbo.Bolums");
        }
    }
}
