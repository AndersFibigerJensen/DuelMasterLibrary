// See https://aka.ms/new-console-template for more information
using ClassMaster.Templates;
using DuelMasterLibrary;
using DuelMasterLibrary.Creatures;
using DuelMasterLibrary.GameMechanics;
using DuelMasterLibrary.Templates;
using DuelMasterLibrary.Worldobjects;
using DuelMasterLibrary;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using Worker;

Console.WriteLine("Hello, World!");

Board diskboard = new Board(20, 20);
Player Player = new Player(20, "name", new DuelMasterLibrary.Position(11, 10));
Wolf wolf = new Wolf(20, "name", new DuelMasterLibrary.Position(10, 10));
List<WorldObject> things = new List<WorldObject> { new Wall {Position=new Position(11,9) }, new Wall {Position=new Position(11,11) } };
things.Add(new flower { Position = new Position(13, 10) });

DuelMasterWorker duelmaster = DuelMasterWorker.Worker;
duelmaster.Initialize(Player);
duelmaster.Start();
duelmaster.AddCreature(wolf);
foreach(WorldObject obj in things)
{
    duelmaster.AddObject(obj);
}




Menu menu = new Menu(duelmaster);
InputType type = InputType.none;
Tracer.Open();
while (type != InputType.quit)
{
    ConsoleKey key = Console.ReadKey().Key;
    Console.Clear();
    type = InputTranslations.translatekey(key);
    menu.FieldMenu(type);
    Console.WriteLine($" Position is {duelmaster.Player.BoardPosition.Col},{duelmaster.Player.BoardPosition.Row} ");
    Console.WriteLine($"Player is facing {StateTranslator.statetranslator(duelmaster.Player.State.CurrentState)}");
}
Tracer.Close();