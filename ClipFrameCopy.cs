using System.Collections.Generic;
using System.Linq;
using UnityEditor.Timeline;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.Timeline;

namespace Assets.Scripts.Editor.ClipFrameCopy
{
    /// <summary>
    /// Timelineで選択されたクリップの開始・終了フレームをクリップボードにコピーするEditor拡張
    /// </summary>
    [MenuEntry("Copy Clip Frames")]
    public class ClipFrameCopy : ClipAction
    {
        /// <summary>
        /// アクションが実行可能か判定するメソッド
        /// </summary>
        /// <param name="clips">選択されたクリップ</param>
        public override ActionValidity Validate(IEnumerable<TimelineClip> clips)
        {
            return ActionValidity.Valid;
        }

        /// <summary>
        /// アクションを実行するメソッド
        /// </summary>
        /// <param name="clips">選択されたクリップ</param>
        public override bool Execute(IEnumerable<TimelineClip> clips)
        {
            // 全てのクリップを対象とする
            var targetClips = clips
                .OrderBy(c => c.start) // 開始時間順にソート
                .ToArray();

            if (targetClips.Length == 0)
            {
                return false;
            }
            
            var timelineAsset = TimelineEditor.inspectedAsset;
            if (timelineAsset == null)
            {
                return false;
            }
            
            double frameRate = timelineAsset.editorSettings.frameRate;
            var resultString = "";

            foreach (var clip in targetClips)
            {
                // TimelineClipの情報は秒単位(double)で保持されているため、
                // Inspectorの表示と一致させるためにdouble精度のまま計算し、Math.Roundで整数化する
                var startFrame = (int)System.Math.Round(clip.start * frameRate);
                var endFrame = (int)System.Math.Round(clip.end * frameRate);

                // 文字列を結合 (例: Run : 10f~20f)
                if (resultString.Length > 0)
                {
                    resultString += "\n";
                }
                resultString += $"{clip.displayName} : {startFrame}f~{endFrame}f";
            }

            // クリップボードにコピー
            GUIUtility.systemCopyBuffer = resultString;

            Debug.Log($"クリップボードにコピーしました:\n{resultString}");
            return true;
        }
    }
}
