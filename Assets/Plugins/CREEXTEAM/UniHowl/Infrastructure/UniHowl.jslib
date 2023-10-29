mergeInto(LibraryManager.library,
    {
        HowlLoad: function (sourceId) {
            sourceId = UTF8ToString(sourceId);
            
            window.HowlLoad(sourceId);
        },
        
                
        HowlState: function (sourceId) {
            sourceId = UTF8ToString(sourceId);

            return window.HowlState(sourceId);
        },
        
                
        HowlCreateAudio: function (sourceId, clipPath, loop, volume, mute, playOnAwake) {
            sourceId = UTF8ToString(sourceId);
            clipPath = UTF8ToString(clipPath);

            window.HowlCreateAudio(sourceId, clipPath, loop, volume, mute, playOnAwake);
        },
        
                
        HowlGlobalMute: function (state) {
            window.HowlGlobalMute(state);
        },
        
                
        HowlGlobalSetVolume: function (volume) {
            window.HowlGlobalSetVolume(volume);
        },
        
                
        HowlSetVolume: function (sourceId, volume) {
            sourceId = UTF8ToString(sourceId);

            window.HowlSetVolume(sourceId, volume);
        },
        
                
        HowlMute: function (sourceId, state) {
            sourceId = UTF8ToString(sourceId);

            window.HowlMute(sourceId, state);
        },
        
                
        HowlStop: function (sourceId) {
            sourceId = UTF8ToString(sourceId);

            window.HowlStop(sourceId);
        },
        
                
        HowlPlay: function (sourceId) {
            sourceId = UTF8ToString(sourceId);

            window.HowlPlay(sourceId);
        },
        
                
        HowlGetPlayTime: function (sourceId) {
            sourceId = UTF8ToString(sourceId);

            return window.HowlGetPlayTime(sourceId);
        },
        
                
        HowlSetPlayTime: function (sourceId, time) {
            sourceId = UTF8ToString(sourceId);

            window.HowlSetPlayTime(sourceId, time);
        },
        
                
        HowlIsPlaying: function (sourceId) {
            sourceId = UTF8ToString(sourceId);

            return window.HowlIsPlaying(sourceId);
        },
        
                
        HowlGetVolume: function (sourceId) {
            sourceId = UTF8ToString(sourceId);

            return window.HowlGetVolume(sourceId);
        },
        
                
        HowlGetLoop: function (sourceId) {
            sourceId = UTF8ToString(sourceId);

            return window.HowlGetLoop(sourceId);
        },
        
                
        HowlSetLoop: function (sourceId, state) {
            sourceId = UTF8ToString(sourceId);

            window.HowlSetLoop(sourceId, state);
        },
        
                
        HowlGetMute: function (sourceId) {
            sourceId = UTF8ToString(sourceId);
            
            return window.HowlGetMute(sourceId);
        },

        HowlSetSound: function (sourceId, clipPath) {
            sourceId = UTF8ToString(sourceId);

            window.HowlSetSound(sourceId, clipPath);
        },

    }
);

