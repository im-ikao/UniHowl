# UniHowl - Unity
UniHowl - Unity - Web Audio made be Easy, Web Audio API, Howler.js

![UniHowl Cover](https://creex.team/assets/images/unihowl.jpg)

I hope you find this asset as useful as I have to integrate WEB Audio API by Howler.JS to
your Unity projects. Unity Engine is a powerful cross-platform game engine, and plugin
allows developers to use Audio across multiple platforms, without problems

You can also go to [Analytics for Yandex Games](https://analytics.creex.team), or [support me](https://boosty.to/creex_team)
Contact me: [Telegram](https://t.me/imikao)

## Overview

UniHowl -  allows developers to use audio through the Web Audio Api, which solves multiple problems in WebGL Builds.

➔ Compatibility: Unity 2021 and Higher

Recommended WebGL Audio Format: mp3

## Features

- Easy to Integrate: The plugin integrates easily into your Unity project. You can quickly connect it and start using Web Audio Api sound without any extra effort. Documentation and code examples will help you quickly understand the functionality of the plugin.
- Support for various audio formats: The plugin supports a wide range of audio formats, including MP3, WAV, OGG and others. You can use any audio format that best suits your project, providing flexibility and ease of use.
- Cross-Platform Compatibility: UniHowl allows audio to be used across multiple platforms, including WebGl, Windows, macOS, iOS, Android and more. Your project will perform equally well on different devices, providing a consistent audio experience for all users without many code changes.
  
## Usage
Import the necessary types into your TypeScript files:

➔ How to use: 
- ◆ First you need create Audio Map (In which all your sounds will be saved as a keyclip), you can made it by press RMB -> Create -> UniHowl -> Audio Map 
- ◆ Specify in the Audio Map all the sounds and their keys that you would like to use 
in the player. 
  - ➔ The name of the key and the name of the audio clip must contain only 
Latin letters and not have special characters, numbers can be used 
  - ➔ The sound should not be located in the Resources folder or subfolder, this 
will lead to an error 
  - ➔ The path along which your sounds lie must also contain only Latin letters 
and not have special symbols, numbers can be used 
- ◆ Next go to Resources folder, and enter to Audio Configuration File, select in 
inspector, your Audio Map. 
- ◆ Just add component <Crossplatform Audio Source> into the object what you 
want, and set settings what you want. 
- ◆ Completely, you can access to this source, as default unity Audio Source. 

➔ How to Build WEBGL: 
- ➔ UniHowl WebGL Template ➔ You need only select UniHowl WebGL Template, 
and audio be work 
- ➔ Custom WebGL Template ➔ You need copy folder “UniHowlJs” to root of your 
WebGL Template, and inject JS files to your html as this code: 

```js
 <script type="text/javascript" src="./UniHowlJs/howler.min.js"></script>
 <script type="text/javascript" src="./UniHowlJs/howler.spatial.min.js"></script>
 <script type="text/javascript" src="./UniHowlJs/WebAudio.js"></script>
```

Follow the order, connect the lines! 

➔ Crossplatform Audio Source: 
- ◆ Fallback Player – What player need be used in Build 
  - ◆ Howl – Prefered Howler.JS Audio Engine. 
  - ◆ Unity – Default Unity Audio Engine 
  - ◆ Key – Setup key of your Sound 
  - ◆ Volume – Setup volume of your Audio 
  - ◆ Loop – Loop this audio source 
  - ◆ Mute – Mute this audio source
   
- ➔ Audio configuration: 
  - ◆ Debug – Enable Unity Audio Engine for Editor. 
  - ◆ Audio – Audio map of sounds.
   
- ➔ Audio map: 
  - ◆ Key – Key of sound, used for playing clip by Audio Source; 
  - ◆ Clip – Clip of sound. 
  - ◆ Preload – Do you need preload sound.
   
- ➔ Entry points of Crossplatform Audio Source: 
  - ◆ Play() – Play source sound; 
  - ◆ Stop() – Stop source sound; 
  - ◆ Volume – Control volume of this source; 
  - ◆ Mute – Mute this source 
  - ◆ Loop – Loop this sosdfasdfsdaund 
  - ◆ SoundKey – Set new sound to this source 
  - ◆ SetGlobalMute(bool) – Mute/Unmute all sources 
  - ◆ SetGlobalVolume(floa) – Set global volume (volume of audio context); 
  - ◆ Load() – Load not preloaded sound 
## Contributing

Contributions to this repository are welcome. If you encounter any issues or have suggestions for improvements, please feel free to open an issue or submit a pull request. Make sure to follow the contribution guidelines outlined in the repository.

## License

The Yandex Games SDK TypeScript types repository is licensed under the MIT License.

I’ve you’ve read until here, thank you! I hope that you enjoy UniHowl and that it makes your 
developer life easier. It would be highly appreciated if you leave a review in the Asset Store, 
and if you want to contact me, don’t hesitate to get in touch through:
- Email: me@ikao.dev, ceo@creex.team
- Telegram: @imikao
