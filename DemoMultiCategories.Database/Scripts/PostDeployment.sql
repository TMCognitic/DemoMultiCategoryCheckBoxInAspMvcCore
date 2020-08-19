/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


Set Identity_Insert Category On;

Insert into Category (Id, Name) values 
(1, 'Comédie'), 
(2, 'Horreur'),
(3, 'Science Fiction');

Set Identity_Insert Category Off;


Set Identity_Insert Movie On;

Insert into Movie (Id, Title, Year) values 
(1, 'Alien, le huitième passager', 1979), 
(2, 'Scary Movie', 2000),
(3, 'Pixels', 2015);

Set Identity_Insert Movie Off;

Insert into MovieCategories (MovieId, CategoryId) values
(1, 2),
(1, 3),
(2, 1),
(3, 1),
(3, 3);