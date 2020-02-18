# social-dance-jukebox

Algorithme de jukebox pour soirée de danses sociales.

## Contexte : le playlist manifesto

Dans le cadre d'un bal rock, concevoir une playlist avec les critères suivants :

  * Chansons durant entre 2min et 4min
  * Playlist de 2h au total (donc environ 40 chansons)  
  * Chansons de tempo entre 30 et 50 MPM (Mesures par Minutes = Battements par minute / 4)
  * Chansons "dansables en rock" (tempo bien marqué, ambiance joviale, présence de break...)
  * Bonne répartition en terme de tempo : gaussienne centrée sur 40 MPM
  * Bonne répartition en terme de genre : Rock / Swing / Pop ...
  * Bonne répartition en terme de période : Oldie / Moderne ...
  * Bonne répartition en terme de fréquence : standard (= passe souvent en soiée) / rare
  
 On peut réaliser manuellement une playlist répondant à ces premiers critères.
 
 On ajoute des nouveaux critères de variabilités :
   * Alternance du tempo (séquence lent / moyen / rapide)
   * Alternance du genre
   * Alternance de la période
   * Alternance de la fréquence
 
 L'idée est que deux chansons qui se suivent dans la playlist doivent varier au maximum sur les 4 critères.
 
 L'alternance du tempo est prioritaire sur les autres.
 
 On se retrouve dans un problème d'optimisation de score nécessaitant l'intervention héroïque de la data science. #turfu
   
 Cas particuliers :
   * les 5 premières chansons doivent être lentes et simples (tempo bien marqué), car elles seront dansées par les débutants du cours débutants qui précéde le bal rock.     
   * la dernière chanson doit être un tube mainstream (pour finir le bal dans une zone de confort)
   
## Set de travail

On se base sur un fichier Excel annoté avec des étiquettes pour les différentes composantes à variabiliser.

[Fichier Excel](https://github.com/sebez/social-dance-jukebox/blob/master/csharp/Tests/SocialDanceJukebox.Infrastructure.Test/Resources/DataChansons.xlsx)

## Définition de la distance

On utilise une [distance "binaire"](https://github.com/sebez/social-dance-jukebox/blob/master/csharp/Sources/SocialDanceJukebox.Domain/Calculs/DistanceBinaire.cs) qui fait la somme de la distance pour chaque coordonnée, avec une valeur 1 si la coordonnée est différente et 0 sinon.

Exception pour le tempo : distance de 1 si le delta est supérieur à 5MPM, 0 sinon.

La distance est donc un nombre entier entre 0 et 4.

## Définition du score de la playlist

On veut maximiser la variabilité.

On va donc faire la somme des distances deux à deux des chansons qui se suivent dans la playlist.

On normalise cette valeur en divisant par la valeur maximale possible, le nombre de transition x la distance maximum.

[Code du score](https://github.com/sebez/social-dance-jukebox/blob/master/csharp/Sources/SocialDanceJukebox.Domain/Calculs/ScoreCalculeur.cs)

## Premières approches

On choisit au hasard le 1er vecteur, puis itérativement le vecteur suivant en optimisant les distances.

Le score maximum atteint est de 64%.

## Architecture

Première version en C#, vite fait en DDD.



