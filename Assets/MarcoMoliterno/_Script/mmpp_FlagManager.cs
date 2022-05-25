using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Marcompp {
    public class mmpp_FlagManager
    {   
        public bool reached;

        private static mmpp_FlagManager _instance;

        public static mmpp_FlagManager GetInstance()
        {
            if(_instance == null)
            {
            _instance = new mmpp_FlagManager();
            }

            return _instance;
        }

        private mmpp_FlagManager()
        {
            reached = false;
        }
        
        void Start() {
        }
    }
}