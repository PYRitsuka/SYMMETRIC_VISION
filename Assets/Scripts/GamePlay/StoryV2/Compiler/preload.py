import json
import glob
import re
import os
from queue import PriorityQueue
import argparse
from env import BASE
def load_json(fp):
    with open(fp,encoding='utf-8') as f:
        data = f.read()
    return json.loads(data)


IMAGE_RESOURCES = {}
PREFIX = f'{BASE}Assets/Addressables/'
def post_process( command_type,target,dtype, value):
    if value.startswith("//"):
        value = value[2:]
    elif target == 'Image':
        value = '图片/'+value
    elif target == 'UI':
        value = 'UI/'+value
    elif target == 'Tachie':
        value = '立绘/'+value
    elif "Text." in command_type:
        value = '文本框/'+value
    elif "Rine" in command_type:
        value = 'Rine/'+value
    assert os.path.exists( PREFIX + value),f'File { PREFIX + value} does not exists!'
    
    return dtype,value.replace("\\","/")
def get_resources(nested_dict,parent_command_type = ''):
    if 'CommandType' in nested_dict:
        command_type = nested_dict['CommandType']
    else:
        command_type = parent_command_type
    target = nested_dict.get('target','')
    for key, value in nested_dict.items():
        if isinstance(value, dict):
            yield from get_resources(value,command_type)
        elif isinstance(value, list):
            for item in value:
                if isinstance(item, dict):
                    yield from get_resources(item,command_type)
        elif isinstance(value, str):
            extension = '.' + value.split('.')[-1]
            if extension in ['.png','.jpg','.bmp','.gif']:
                if indices:= re.compile("{(\d+)-(\d+)}").findall(value):
                    start,end = indices[0]
                    start = int(start)
                    end = int(end)
                    value = re.sub("{(\d+)-(\d+)}","{}",value)
                    for i in range(start,end):
                        yield command_type,target,'Texture', value.replace("{}",str(i))
                else:
                    yield command_type,target,'Texture', value
            elif extension in ['.mp4',]:
                yield command_type,target,'VideoClip', value
            elif extension in ['.ogg','.wav','.mp3']:
                yield command_type,target,'AudioClip', value
            elif extension in ['.json']:
                yield command_type,'','Script', value

    
def remove_prefix(x):
    x = x.replace(PREFIX,'').replace("\\","/")
    return x


class SVGarph:

    def __init__(self) -> None:
        self.nodes = {} # str -> List[(str,str)]
        self.neighbors = {} # str -> List[str] // neighbors

    def get_node(self,k):
        return self.nodes[k]
    
    def add_node(self,k):
        if k not in self.nodes:
            self.nodes[k] = set()
    
    def add_resources(self,k,dtype,fname):
        self.add_node(k)
        self.nodes[k].add((dtype,fname))

    def add_edges(self,k1,k2):
        if k1 == k2: 
            return
        if k1 not in self.neighbors:
            self.neighbors[k1] = set()
        if k2 not in self.neighbors:
            self.neighbors[k2] = set()
        self.neighbors[k1].add(k2)
        self.neighbors[k2].add(k1)

    def get_neighbors(self,root,depth):
        # BFS
        all_neighbors = []
        seen = set()
        queue = PriorityQueue()
        queue.put((0,root))
        while not queue.empty():
            curr_depth,first = queue.get()
            if first in seen:
                continue
            seen.add(first)
            if curr_depth > depth:
                continue
            all_neighbors.append((curr_depth,first))
            for child in self.neighbors.get(first,[]):
                assert type(child) == str,child
                queue.put((curr_depth+1,child))
        return all_neighbors
    
    def get_neighbor_resources(self,root,depth=2):
        all_resources = set()
        for _,node in self.get_neighbors(root,depth):
            print(f"Preload {len(self.nodes[node])} Resources from {node} to {root}")
            for res in self.nodes[node]:
                all_resources.add(res)
        return list(all_resources)

def test_bfs():
    graph = SVGarph()
    GRAPH = '''
    1  - 2 - 3 - 4 - 5 - 6 - 7 - 8 -9 - 10 - 11
    1 -------5
    '''
    print(GRAPH)
    for i in range(2,12):
        graph.add_edges(str(i-1),str(i))
    graph.add_edges(str(1),str(5))
    for d in range(5):
        print(f"Depth {i} Neighbor of Node 1")
        for depth,res in graph.get_neighbors("1",d):
            print(f"\t {depth} {res}")


if __name__ == "__main__":
    parser = argparse.ArgumentParser()
    parser.add_argument('--force',action='store_true') # ignored
    parser.add_argument('--optimized',action='store_true')
    compiled_json = glob.glob(PREFIX + '脚本/V2/**/*.json',recursive=True)
    args = parser.parse_args()
    compiled_scripts = {remove_prefix(k):load_json(k) for k in compiled_json }
    graph = SVGarph()
    for k,v in compiled_scripts.items():
        graph.add_node(k)
        print(f'----- Resources in {k} ------')
        for r in get_resources(v):
            dtype,resource_name = post_process(*r)
            if dtype == 'Script':
                print(f"\tLink: {k}<--->{resource_name}")
                graph.add_edges(k,resource_name)
            else:
                graph.add_resources(k,dtype,resource_name)
    final_results = {}
    for k,v in compiled_scripts.items():
        print(f'-----------------{k}---------------------')
        final_results[k] = graph.get_neighbor_resources(k,2)
    for k,v in final_results.items():
        print(f"{k}: {len(v)} Resources")
    dump_args = {}
    if not args.optimized:
            dump_args = dict(indent=2)
    with open(f'{BASE}Assets/Addressables/脚本/V2_Preload/preload.json','w',encoding="utf-8") as f:
        f.write(json.dumps(final_results,ensure_ascii=False,**dump_args))
        