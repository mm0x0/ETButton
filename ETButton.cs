using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent (typeof (EventTrigger))]
public sealed class ETButton : MonoBehaviour
{
	// タップイベントを設定
	public void RegistTouchEvent (UnityAction f)
		=> SetEvent (f, EventTriggerType.PointerDown);

	// クリックイベントを設定
	public void RegistClickEvent (UnityAction f)
		=> SetEvent (f, EventTriggerType.PointerClick);

	// ロールオーバーイベントを設定
	public void RegistRolloverEvent (UnityAction f)
		=> SetEvent (f, EventTriggerType.PointerEnter);

	// ロールアウトイベントを設定
	public void RegistRolloutEvent (UnityAction f)
		=> SetEvent (f, EventTriggerType.PointerExit);

	// タッチイベントの設定
	public void SetEvent (UnityAction f, EventTriggerType type)
	{
		// 重複登録させない
		RemoveEvent (f);

		// イベントエントリーを作成してEventTriggerに追加
		var entry = new TouchEntry (f);
		entry.eventID = type;
		entry.callback.AddListener ((x) => f ());
		GetComponent<EventTrigger> ().triggers.Add (entry);
	}

	// タッチイベントの削除
	// * 引数ActionとTouchEntryのアクションが一致したら削除する
	public void RemoveEvent (UnityAction f)
	{
		TouchEntry tgtEntry = null;

		foreach (EventTrigger.Entry entry in GetComponent<EventTrigger> ().triggers)
		{
			if (!(entry is TouchEntry))
				continue;

			if ((entry as TouchEntry).f == f)
				tgtEntry = (entry as TouchEntry);
		}

		if (tgtEntry != null)
			GetComponent<EventTrigger> ().triggers.Remove (tgtEntry);
	}
}

// Actionを保持するEventTrigger.Entryクラス
class TouchEntry : EventTrigger.Entry
{
	public UnityAction f;
	public TouchEntry (UnityAction f) : base () => this.f = f;
}