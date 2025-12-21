# MagicTilesDemo



\## Overview: Magic Tiles Unity Game 2D Demo. This is a rhythm-based 2D Unity game inspired by mobile tile-tapping games.



\## How to Run the Project

* Unity Version: 2021.3.45f2. Please open it with the same or a compatible version.
* Target platform: Android
* Open Project: Clone or download this repository, then open it in Unity Hub.
* Run the Scene: Can be run directly from the main scene or run indirectly from the menu scene.
* Note: the test file is available at the link: https://drive.google.com/file/d/1K50tzIdNpnd3D3ZTZv7ALDMbUQSHpioK/view?usp=sharing
* Video demo: https://www.youtube.com/shorts/BPlTO5EUBks



\## Design choices

* Used manager objects (GameManager, ScoreManager, SoundManager...) and prefabs to organize game logic and state.
* Applied the Singleton design pattern to ensure global access to manager instances.
* Implemented a simple beat detection technique to spawn tiles in sync with background music.
* Used event/delegate to follow the Observer design pattern, enabling decoupled communication between components.
* Integrated Object Pooling to efficiently reuse objects, improving performance.
* Use Addressable to load resources dynamically.
* Apply Shader Graph for timing bar.


\## Reference:

Brackeys's Youtube channel: https://www.youtube.com/@Brackeys

Brackeys's Github: https://github.com/Brackeys



\## Folder Structure:

Assets/

|-- Scripts/

| |-- Managers/

| | |-- GameManager.cs

| | |-- PoolManager.cs

| | |-- ScoreManager.cs

| | |-- SoundManager.cs

| | |-- Spawner.cs

| |-- Objects/

| | |-- Border.cs

| | |-- Note.cs

| | |-- TimingBar.cs

| |-- Prefabs/

| | |-- Tile.cs

| | |-- TileEffect.cs

| |-- UI/

| | |-- CompleteSong.cs

| | |-- GameOver.cs

| | |-- Menu.cs

|-- Prefabs/

| |-- Tile.prefab

| |-- TileEffect.prefab

|-- Scenes/

| |-- MenuScene.unity

| |-- MainScene.unity

|-- Materials/

| |-- Laser.mat

|-- Renderer/

| |-- Lazer2D.shadergraph



\## Contact

For questions or feedback, feel free to reach out via GitHub Issues or email.

