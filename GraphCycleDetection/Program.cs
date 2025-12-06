
//Edges represent connections between graph nodes
int[,] edges = { { 1, 2 }, { 3, 4},  { 5, 6 }, { 7, 8}, { 1, 3 }, {2,5}, { 5, 7 }, { 6, 8 } };
var result = DetectCycle(edges);
Console.WriteLine("Cycle Detected : {0}", result.Item1);

/*Function to detect cycle in a graph using an array*/
Tuple<bool,int,int> DetectCycle(int[,]edges)
{
    int[] graph = new int[edges.Length];
    //Filling the array with -1. It means it is root
    Array.Fill(graph,-1);
     
    for (int i = 0; i < graph.Length; i++)
    {
        var rootOfA = FindRootIndex(graph,edges[i,0]);
        var rootOfb = FindRootIndex(graph,edges[i,1]);
        if( rootOfA == rootOfb) return Tuple.Create(true,edges[i,0],edges[i,1]) ;
        
        if (graph[edges[i,0]] == -1)
        {
            graph[edges[i,1]] = edges[i,0];
        }   
    }
    return Tuple.Create(false,-1,-1);
}

int FindRootIndex(int[] graph, int index)
{
    while (true)
    {
        var value = graph[index];
        if (value == -1) return index;
        index = value;
    }
}