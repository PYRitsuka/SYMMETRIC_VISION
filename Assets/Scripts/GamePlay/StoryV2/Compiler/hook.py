import os
from resolver import parse_file,ScriptResolver,load_text,parse_string
import json
import glob
import argparse
from env import BASE

def parse_one_file(fp,force = False,optimized=True):
    
    outfile = fp.replace('.csx','.json')
    need_recompile = False
    text = None
    if force:
        need_recompile = True
    elif not os.path.exists(outfile):
        need_recompile = True
    elif os.path.getmtime(fp) > os.path.getmtime(outfile):
        need_recompile = True
    else:
        text = load_text(fp)
        if '#Editor-Recompile=true' in text:
            need_recompile = True

    if not need_recompile:
        print(f"Python: Skipped {fp}")
        return
    else:
        print(f"Python: Compiling {fp}")
        dump_args = {}
        if not optimized:
            dump_args = dict(indent=2)
        if text is None:
            text = load_text(fp)
        tree,str_tree = parse_string(text)
        tree_parsed = ScriptResolver().build_tree(tree)
        tree_parsed = {"Commands":tree_parsed}
        with open(outfile,'w',encoding="utf-8") as f:
            f.write(json.dumps(tree_parsed,ensure_ascii=False,**dump_args))
    print(f"Python: Compiled {fp}")

if __name__ == "__main__":
    parser = argparse.ArgumentParser()
    parser.add_argument('--force',action='store_true')
    parser.add_argument('--optimized',action='store_true')
    args = parser.parse_args()
    force = args.force
    optimized=args.optimized
    print("HERE IS THE BUILD TEST!!!!!")
    files = glob.glob(f'{BASE}Assets/Addressables/脚本/V2/**/*.csx',recursive=True)
    print(f'Search In Path{BASE}Assets/Addressables/脚本/V2/**/*.csx')
    print(files)
    for fp in files:
        parse_one_file(fp,force,optimized)

    # Compile Preloading

