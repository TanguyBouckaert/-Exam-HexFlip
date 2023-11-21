h2/

* November 9 - November 16:
* Hexagonal GridPosition
* PositionHelper class
* Tile Model + TileView
Board Model + BoardView
Find Tiles in scene + create Tile Model (through Board Model) + Link TileView with Tile Model
Detect click on TileView
Set IsHighlighted on Tile Model
Update Highlight material in TileView when IsHighlighted changes

November 16 - November 23
Piece Model + PieceView 
Difference with chess: Position is fixed in HexFlip, but PlayerColor can be changed (flip pieces)
Piece Prefab: 1 prefab made up of 2 cylinders. Player Color determines rotation.
Board: Place / Remove piece (we will need remove for undo later)
BoardView: Spawn PiecePrefab
Detect Click on PieceView -> call method in Piece -> call method in Board
BoardTester class to test the functionalities. Also try to test all functionalities up to this point!
TIP: As mentioned in class, we saw two ways of passing the input action "clicked" to the board:

in Tile.cs we created a Clicked event, the Board model registers to the event.
in Piece.cs we passed the Board model through the constructor, and call PieceClicked directly from Piece.cs.
Both are fine, but you shouldn't mix them up like we did in class. It is recommended to pick the style that you feel the most comfortable with and use it for both.
