package main

func main() {

}

func FindRoot(graph []int, index int) int {
	for {
		value := graph[index]
		if -1 == value {
			return index
		}
		index = value
	}
}

func DetectCycle(edges [][]int) (bool, int, int) {
	graph := make([]int, len(edges))
	//Fill the graph array with -1
	for index := range graph {
		graph[index] = -1
	}

	for i := 0; i < len(graph); i++ {
		rootA := FindRoot(graph, edges[i][0])
		rootB := FindRoot(graph, edges[i][1])
		if rootA == rootB {
			return true, rootA, rootB
		}

		if graph[edges[i][0]] == -1 {
			graph[edges[i][1]] = edges[i][0]
		}
	}
	return false, -1, -1
}
