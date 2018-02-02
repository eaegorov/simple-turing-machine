using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Turing_Machine.TuringMachineLib
{
    class programReader
    {
        public enum INPUT_CODE
        {
            SUCCESSFUL, 
            FILE_NOT_FOUND, 
            NO_INIT_STATES, 
            NO_ACCEPT_STATES,
            BAD_TRANSITION,
            TAPE_COUNTS_NOT_MATCH
        }
        public INPUT_CODE ReadFromFile(ref TuringMachine tm, String path)                         // Return true if input is correct
        {
            const char comma = ',';
            const String initString = "init: ";
            const String acceptString = "accept: ";
            const char moveLeft = '<';
            const char moveRight = '>';
            const char hold = '-';

            int stateCount = 0;
            int tapeCount = 0;

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    StringBuilder sb = new StringBuilder();
                    List<string> states = new List<string>();
                    

                    String line;

                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        while ( line.Length == 0 || line[0] == '/' )
                            line = sr.ReadLine();

                        if ( !tm.hasInitState && line.Substring(0, initString.Length) == initString )
                        {                            
                            sb.Append(line, initString.Length, line.Length - initString.Length);
                            tm.CurrentState = sb.ToString();
                            tm.initState = sb.ToString();
                            sb = new StringBuilder();
                            continue;
                        }

                        if( line.Length >= acceptString.Length && line.Substring(0, acceptString.Length) == acceptString )
                        {
                            for(int i = acceptString.Length; i < line.Length; i++)
                            {
                                if ( line[i] != comma )
                                    sb.Append(line[i]);
                                else
                                {
                                    tm.Add_AcceptState(sb.ToString());
                                    sb = new StringBuilder();
                                }
                            }

                            if ( sb.Length > 0 )
                            {
                                tm.Add_AcceptState(sb.ToString());
                                sb = new StringBuilder();
                            }
                            continue;
                        }
                                                
                        if( line.Length > 1 )
                        {
                            String currentState = "";
                            List<char> currentChars = new List<char>();
                            String newState = "";
                            List<char> newChars = new List<char>();
                            List<Action> actions = new List<Action>();

                            int i;
                            for(i = 0; i < line.Length; i++)                // Find transition current state
                            {
                                if ( line[i] != comma )
                                    sb.Append(line[i]);
                                else
                                {
                                    currentState = sb.ToString();
                                    sb = new StringBuilder();
                                    break;
                                }
                            }

                            for(; i < line.Length; i++)
                            {
                                if ( line[i] == comma )
                                    continue;
                                
                               currentChars.Add(line[i]);
                            }
                            

                            line = sr.ReadLine();

                            for(i = 0; i < line.Length; i++)
                            {
                                if ( line[i] != comma )
                                    sb.Append(line[i]);
                                else
                                {
                                    newState = sb.ToString();
                                    sb = new StringBuilder();
                                    break;
                                }
                            }

                            for(; i < line.Length; i++)
                            {
                                if ( line[i] == comma )
                                    continue;



                                if( line[i] == moveLeft )
                                {
                                    actions.Add(Action.MOVE_LEFT);
                                    continue;
                                }

                                if( line[i] == moveRight )
                                {
                                    actions.Add(Action.MOVE_RIGHT);
                                    continue;
                                }

                                if( line[i] == hold )
                                {
                                    actions.Add(Action.HOLD);
                                    continue;
                                }

                                newChars.Add(line[i]);

                            }
                            

                            if( currentState.Length == 0 )
                                return INPUT_CODE.BAD_TRANSITION;
                            if( currentChars.Count == 0)
                                return INPUT_CODE.BAD_TRANSITION;
                            if( newState.Length == 0)
                                return INPUT_CODE.BAD_TRANSITION;
                            if( newChars.Count == 0)
                                return INPUT_CODE.BAD_TRANSITION;
                            if( actions.Count == 0)
                                return INPUT_CODE.BAD_TRANSITION;

                            if( currentChars.Count != newChars.Count 
                                && currentChars.Count != actions.Count)
                                return INPUT_CODE.BAD_TRANSITION;

                            if (tapeCount == 0)  
                                tapeCount = currentChars.Count;
                            else
                            {
                                if (tapeCount != currentChars.Count)
                                    return INPUT_CODE.TAPE_COUNTS_NOT_MATCH;
                            }

                            Transition newTransition;

                            newTransition.currentState = currentState;
                            newTransition.currentChars = currentChars;
                            newTransition.newState = newState;
                            newTransition.newChars = newChars;
                            newTransition.actions = actions;

                            tm.AddTransition(newTransition);
                        }
                    }
                    
                }
            }
            catch (Exception e)
            {
                return INPUT_CODE.FILE_NOT_FOUND;
            }

            if (!tm.hasInitState)
                return INPUT_CODE.NO_INIT_STATES;

            if (tm.acceptStates.Count == 0)
                return INPUT_CODE.NO_ACCEPT_STATES;

            for (int i = 0; i < tapeCount; i++)
                tm.tapes.Add(new Tape());

            return INPUT_CODE.SUCCESSFUL;
        }
    }
}
