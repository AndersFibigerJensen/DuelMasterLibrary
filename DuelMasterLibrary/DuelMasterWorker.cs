using DuelMasterLibrary.Creatures;
using DuelMasterLibrary.GameMechanics;
using DuelMasterLibrary.Templates;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DuelMasterLibrary
{
    public class DuelMasterWorker
    {
        private List<Creature> _creatures;
        private List<WorldObject> _objects;
        private SaveFile file= new SaveFile();
        private Board board;

        private static DuelMasterWorker? _instance;


        public static DuelMasterWorker Worker
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DuelMasterWorker();
                }
                return _instance;
            }
        }

        private DuelMasterWorker()
        {
            this._creatures = new List<Creature>();
            this.board = new Board(0, 0);
            this._objects = new List<WorldObject>();
        }

        public Player? Player { get; set; }

        /// <summary>
        /// Starter DuelMasterWorker ig sørger for at alt Deserializes hvis der er noget
        /// og sørger for at alle creatures bruger den samme DuelMasterWorker 
        /// </summary>
        public void Start()
        {
            Loading();
            workercreature();

        }

        /// <summary>
        /// Kigger på en Position for at se om det er muligt at gå i den retning
        /// </summary>
        /// <param name="position">en postion som bliver kigget på for at se om der er muligt at rykke fremad  </param>
        /// <returns>returnere sandt hvis det er muligt at gå i den retning og falsk hvis det ikke er muligt at gå fremad</returns>
        public bool examinemovement(Position position)
        {
            if (position.Row >= board.Row || position.Col >= board.Col)
                return false;
            if (position.Row == 0 || position.Col == 0)
                return false;
            if (ExamineCreature(position) != null)
                return false;
            if (ExamineObject(position) != null)
                return false;
            return true;
        }

        /// <summary>
        /// ser om en creature er på en position
        /// </summary>
        /// <param name="position">den position funktionen skal kigge på</param>
        /// <returns>returnere en creature hvis der er en creature på position eller returneres null</returns>
        public Creature? ExamineCreature(Position position)
        {
            List<Creature>? creature =_creatures.Where(a => a.BoardPosition.Row == position.Row && a.BoardPosition.Col==position.Col).ToList();
            if (creature.Count != 0)
                    return creature[0];
            return null ;
        }

        /// <summary>
        /// bruges til at se om et worldobject er på en position
        /// </summary>
        /// <param name="position">den position der måske har et worldobject</param>
        /// <returns>returnere et worldobject hvis det eksistere på position ellers returnere funktionen null</returns>
        public WorldObject? ExamineObject(Position position)
        {
            List<WorldObject>? worldobject = _objects.Where(a => a.Position.Col == position.Col && a.Position.Row==position.Row).ToList();
            if (worldobject.Count==0)
                return null;
            return worldobject[0];
        }

        /// <summary>
        /// tilføjer en creature på brættet
        /// </summary>
        /// <param name="creature">den creature som skal sættes på brættet</param>
        public void AddCreature(Creature creature)
        {
            if(examinemovement(creature.BoardPosition)==true)
            {
                creature.Worker = _instance;
                _creatures.Add(creature);
            }

        }

        /// <summary>
        /// indlæser en spiller til DuelMasterWorker
        /// </summary>
        /// <param name="player"></param>
        public void Initialize(Player player)
        {
            Player = player;
        }


        /// <summary>
        /// tilføjer et worldobject til DuelMasterWorker
        /// </summary>
        /// <param name="worldobject">Det worldobject som tilføjes tilføjes til DuelMasterWorker</param>
        public void AddObject(WorldObject worldobject)
        {
            if (examinemovement(worldobject.Position) == true)
                _objects.Add(worldobject);
            Tracer.traceinfo(worldobject.ToString());
        }


        /// <summary>
        /// Loader Creatures og worldobjects og brætter ind ved at Deserializerer og tilføje de deserializere objekter
        /// til DuelMasterWorker
        /// </summary>
        public void Loading()
        {
            //file.Deserializeall();
            //if(file.board!=null)
            //{
            //    board = file.board;
            //}
            //if (file.creatures != null)
            //    _creatures = file.creatures;
            //if (file.objects != null)
            //    _objects = file.objects;
            //if(Player!=null)
            //{
            //    file.Player=Player;
            //}

            file.LoadBoard();
            board=file.board;
        }


        /// <summary>
        /// Gør at alle creatures i DuelMasterWorker bruger den samme DuelMasterWorker
        /// </summary>
        public void workercreature()
        {
            AddCreature(Player);
            foreach (Creature creature in _creatures) 
            {
                creature.Worker = Worker;
            }
            Player.Worker = Worker;
            AddCreature(Player);

        }

        public void removeobject(WorldObject obj)
        {
            _objects.Remove(obj);
        }

    }
}
