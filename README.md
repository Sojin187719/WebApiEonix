# WebApiEonix
## Choix d'implémentation

###### 1. Service **ServiceCollectionExtensions**
Ce service a été créé pour centraliser les différentes méthodes de *IServiceCollection* ou autres fonctionnalités en dehors du **startup**. Le startup ne doit s'occuper que de lancer les différentes instances et ne doit pas se préoccuper à comment les créer.  
###### 2. Hiérarchie de l'API
L'api est divisée en trois parties : 
  1. Api -> Contient les points d'entrées dans Contnroller, **startup** et **program** ainsi que les différents settings du projet dans **appsettings**.
  2. Core -> Contient le corps de l'APi (Models, Services, Repositories, etc). 
  3. Configuration -> Contient un fichier de configuration utilisé dans toute l'API pour stocker l'ensemble des settings de toute l'API. 
###### 3. Repository Pattern
Pattern permets une abstraction de la couche d'accès aux données. La façon dont on modifie les données de la base de données ou la façon dont on les reçoit sont cachées dans les repositories. De ce fait, le Controller ne doit pas se soucier de cette partie et ne s'occupe que d'appeler le repository nécessaire pour le fonctionnement de ses méthodes. 
###### 4. Tests unitaires
Ils n'ont pas été réalisé par manque de temps. 
###### 5. **GetManyPerson(string name, string firstName)**
Etant donné que l'énnoncé n'a pas décrit en détail la liste de personnes à reçevoir en dehors des filtres, il a été décidé de reçevoir toutes les personnes de la table lorsque les filtres sont null. Dans le cas contraire, on utilise la méthode Contains pour récupérer les personnes avec les champs demandés. 
###### 6. SQLServer
SqlServer a été utilisé comme moteur DB étant donné que j'ai travaillé uniquement avec celui-ci lors de la réalisation de mes WEB API. 





