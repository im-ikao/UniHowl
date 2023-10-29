const audioPath = "./StreamingAssets/Audio/";
const sourceDictionary = {};

function IsSourceExists(sourceId) {
    if (sourceDictionary[sourceId])
        return true;
    else
        return false;
}

function HowlLoad(sourceId)
{
    if (!IsSourceExists(sourceId))
        return; // EXCEPTION?

    sourceDictionary[sourceId].load();
}

function HowlState(sourceId)
{
    if (!IsSourceExists(sourceId))
        return; // EXCEPTION?

    return sourceDictionary[sourceId].state; // Check the load status of the Howl, returns a unloaded, loading or loaded.
}

function HowlCreateAudio(sourceId, clipPath, loop, volume, mute, playOnAwake)
{
    if (IsSourceExists(sourceId))
        return; // EXCEPTION?

    var src = audioPath + clipPath;

    var source = new Howl({
        src: [src],
        html5: false,
        loop: Boolean(loop),
        autoplay: Boolean(playOnAwake),
        volume: volume,
        mute: Boolean(mute),
        preload: true
    })

    sourceDictionary[sourceId] = source;
}

function HowlSetSound(sourceId, clipPath)
{
    if (!IsSourceExists(sourceId))
        return;

    var src = audioPath + clipPath;

    var source = new Howl({
        src: [src],
        html5: sourceDictionary[sourceId].html5,
        loop: sourceDictionary[sourceId].loop,
        autoplay: sourceDictionary[sourceId].autoplay,
        volume: sourceDictionary[sourceId].volume,
        mute: sourceDictionary[sourceId].mute
    })

    sourceDictionary[sourceId] = source;
}

function HowlGlobalMute(state)
{
    Howler.mute(state);
}

function HowlGlobalSetVolume(volume)
{
    Howler.volume(volume);
}


function HowlSetVolume(sourceId, volume)
{
    if (!IsSourceExists(sourceId))
        return; // EXCEPTION?

    sourceDictionary[sourceId].volume(volume);
}

function HowlMute(sourceId, state)
{
    if (!IsSourceExists(sourceId))
        return; // EXCEPTION?

    sourceDictionary[sourceId].mute(state);
}

function HowlStop(sourceId)
{
    if (!IsSourceExists(sourceId))
        return; // EXCEPTION?

    sourceDictionary[sourceId].stop();
}

function HowlPlay(sourceId)
{
    if (!IsSourceExists(sourceId))
        return; // EXCEPTION?


    sourceDictionary[sourceId].play();
}

function HowlGetPlayTime(sourceId)
{
    if (!IsSourceExists(sourceId))
        return; // EXCEPTION?

    return sourceDictionary[sourceId].seek;
}

function HowlSetPlayTime(sourceId, time)
{
    if (!IsSourceExists(sourceId))
        return; // EXCEPTION?

    sourceDictionary[sourceId].seek(time);
}

function HowlIsPlaying(sourceId)
{
    if (!IsSourceExists(sourceId))
        return; // EXCEPTION?

    sourceDictionary[sourceId].playing();
}

function HowlGetVolume(sourceId)
{
    if (!IsSourceExists(sourceId))
        return; // EXCEPTION?

    return sourceDictionary[sourceId].volume;
}

function HowlGetLoop(sourceId)
{
    if (!IsSourceExists(sourceId))
        return; // EXCEPTION?

    return sourceDictionary[sourceId].loop;
}

function HowlSetLoop(sourceId, state)
{
    if (!IsSourceExists(sourceId))
        return; // EXCEPTION?

    return sourceDictionary[sourceId].loop(state);
}

function HowlGetMute(sourceId)
{
    if (!IsSourceExists(sourceId))
        return; // EXCEPTION?

    return sourceDictionary[sourceId].mute;
}