# NEGOSUD

### Stack : 
- .NET 7 + EF Core
- GO

### Base de données

- PostgreSQL

### Versioning : 

- Git
- GitHub

### Gestion de projet : 

-Jetbrains Space

### Hébergement

- AWS / EC2 T2.micro

--- 

# Préambule

La société NEGOSUD est un négociant en vin situé en Gascogne.
En accord, avec ses partenaires (Les domaines de Tariquet, Pelleheaut, Joy, Vignoble Fontan et
Uby), il propose la dégustation et la vente de l’ensemble de leurs produits.

### Module - Gestion des stocks

L’utilisateur devra pouvoir :

- Créer les clients, des fournisseurs, les familles (Rouge, Rosé, Blanc,
Pétillants, Digestifs), les articles etc

- Modifier les stocks unitairement, s’il vend un produit disponible en
quantité suffisante

- Passer des commandes (référence / quantité / date) auprès d’un
fournisseur (cela rend obligatoire le lien entre une référence [=article] ET
un fournisseur)

### Module - Gestion d’inventaire

L’utilisateur se chargera :

- D’inventorier l’ensemble des articles et pourra régulariser son stock en
masse.

### Module - Commandes fournisseurs et clients

- Les clients peuvent passer commande à n’importe quel moment, même si le stock
est insuffisant.

- Si le stock d’un article est insuffisant ou son seuil minimum est atteint, une
commande fournisseur sera créée automatiquement sous forme d’un bon de
commande et quand son statut sera livré, la quantité s’ajoutera au stock.

- Bonus : le réapprovisionnement automatique pourra être désactivé à
l’aide d’une action utilisateur, via l’interface de gestion
