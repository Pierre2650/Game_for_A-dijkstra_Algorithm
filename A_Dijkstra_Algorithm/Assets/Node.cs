using UnityEngine;

public class Node
{
  
        public Vector2 position;
        public Node parent = null;
        public float distance;

        
        public Node(Vector2 position, float distance)
        {
            this.position = position;
            this.distance = distance;
        }

        public Node(Vector2 position, float distance, Node parent)
        {
            this.position = position;
            this.distance = distance;
            this.parent = parent;
        }
    
}
