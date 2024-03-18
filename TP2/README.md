# TP - Reprise d'un projet Legacy

## 0 - Lancement du projet

```bash
dotnet run --project PuissancequatreMorpion
```
```bash
dotnet test
```

## I - Les difficultés liées à la validation

> Listez les éléments du logiciel qui sont des freins à la validation du logiciel dans son
> état actuel. A l’aide d’exemples issus du code, expliquez les soucis posés par les choix de
> design qui ont été effectués par le prestataire.

Pour commencer, l’implémentation du code dans la fonction Main, sans aucun découpage en fonction, ne permet pas de tester aisément cette partie du code. La complexité cyclomatique est très élevée. Pour tester chaque sous-cas il faudrait énormément de tests. Même si on les créées, ces tests seraient mal découpés.

Ensuite, la fonction BoucleJeu est très similaire entre la class PuissanceQuatre et Morpion. Cette fonction va donc devoir être testée deux fois au lieu d’une seule dans le cas ou on avait une class qui gérait la partie, qu’importe le jeu choisi.

De plus, cette même fonction est probablement trop longue, il y a beaucoup de boucles et de conditions se qui la rend également difficile à tester.

Il y donc beaucoup de code dupliqué, ce qui augmente d'autant plus le nombre de tests à effectuer.

En bref, tester le code dans ces conditions est très difficile. Il faudrait donc remanier le code en respectant les principes de POO afin de pouvoir faire la validation correctement.


## II - Les méthodes de résolution de ces problèmes


>Expliquez les actions à mettre en place pour valider l’existant, et le cas échéant, pour corriger les bugs éventuels.


Comme dit précédemment, valider l'entièreté de l'existant est une tâche complexe. Dans un premier temps on peut imaginer simplement tester les fonctions les plus simples à tester, à savoir, pour chaque jeux, celles qui déterminent si un jour à gagner et celles qui déterminent si il y a égalité. Pour tester les autres fonctionnalités, il faudra d'abord refacto le code afin de réduire la complexitée cyclomatique des fonctions.

Après avoir écrit quelques tests, on dirait que la fonction de validation de la victoire du morpion ne fonctionne pas dans certains cas. Pour régler ces problèmes je pourrais essayer de la corriger, mais je préfère directement passer à la refacto du code afin de régler tout les problèmes d'un coup.

Il faudrait restructurer l'ensemble du projet en utilisant différents design paterns. Le DP strategy pourrait être utilisé pour choisir entre les différents jeux. On pourrait également restructurer l'application sous forme d'un MVC (Modèle vue contrôleur) pour séparer les données, l'interface utilisateur (console) et la logique.

### II.3 Reprendre et améliorer le code existant

## III - Le développement des fonctionnalités manquantes

> Expliquez comment vous souhaitez procéder pour « brancher » un joueur contrôlé par l’ordinateur ainsi qu’un système permettant l’historisation et la persistance.

Pour le système d'historisation et persistance des parties (sauvegarde), il est possible d'utiliser le design pattern Observer et de l'inclure dans notre architecture MVC. A chaque fois que le joueur ou l'ordinateur joue, la vue sera notifié. Il est alors possible de brancher notre systèle de sauvegarde qui sera aussi notifié lors de modifications, et alors d'enregistrer ce que le ou les joueurs font. Il suffira ensuite de restaurer la sauvegarde au lancement du jeu.

Pour le système de joueur contrôle par ordinateur, il faudrait créer deux classes `HumanPlayer` et `ComputerPlayer` héritant d'une classe abstraite `Player`. Ces classes définiraient la manière de jouer.