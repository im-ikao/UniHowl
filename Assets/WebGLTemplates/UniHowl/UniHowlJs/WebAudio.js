const audioPath = "./StreamingAssets/Audio/";
const sourceDictionary = {};
const sourceSpatialDictionary = {};
const sourcePositionDictionary = {};

function IsSourceExists(sourceId) {
    if (sourceDictionary[sourceId])
        return true;
    else
        return false;
}

function IsSourceSpatialOptionsExists(sourceId) {
    if (sourceSpatialDictionary[sourceId])
        return true;
    else
        return false;
}

function IsSourcePositionExists(sourceId) {
    if (sourcePositionDictionary[sourceId])
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

    if (IsSourcePositionExists(sourceId))
        HowlSetPosition(sourceId, sourcePositionDictionary[sourceId]);
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

function HowlSetPan(sourceId, options) {
    sourceSpatialDictionary[sourceId] = options;

    if (!IsSourceExists(sourceId))
        return; // EXCEPTION?

    sourceDictionary[sourceId].pannerAttr(options);
}

function HowlSetPosition(sourceId, x, y, z)
{
    sourcePositionDictionary[sourceId] = {
        x: x,
        y: y,
        z: z
    };

    if (!IsSourceExists(sourceId))
        return; // EXCEPTION?

    sourceDictionary[sourceId].pos(x,y,z);

    if (!IsSourceSpatialOptionsExists(sourceId))
        return; // EXCEPTION?

    sourceDictionary[sourceId].pannerAttr(sourceSpatialDictionary[sourceId]);

}

function HowlAudioListenerSetPosition(x, y, z)
{
    Howler.pos(x, y, z);
}

function HowlAudioListenerSetRotation(x, y, z, xUp, yUp, zUp)
{
    Howler.orientation(x, y, z, xUp, yUp, zUp);
}