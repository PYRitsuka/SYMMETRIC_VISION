cd /D "%~dp0"
:: added cd to make sure it works for any directory
python Assets\Scripts\GamePlay\StoryV2\Compiler\hook.py %*
python Assets\Scripts\GamePlay\StoryV2\Compiler\preload.py %*