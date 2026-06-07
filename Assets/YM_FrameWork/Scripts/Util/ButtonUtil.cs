using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public static class ButtonUtil
{
    public static void AddEvent(this Button button, EventTriggerType triggerType, UnityEngine.Events.UnityAction<BaseEventData> action)
    {
        if (button == null) return;

        // 1. EventTrigger 컴포넌트 확보
        EventTrigger trigger = button.gameObject.GetComponent<EventTrigger>();
        if (trigger == null) trigger = button.gameObject.AddComponent<EventTrigger>();

        // 2. [중복 방지] 동일한 타입의 기존 이벤트가 있다면 제거
        // '하나의 이벤트에는 하나만 넣는다'는 규칙 적용
        trigger.triggers.RemoveAll(entry => entry.eventID == triggerType);

        // 3. 새로운 이벤트 추가
        EventTrigger.Entry newEntry = new EventTrigger.Entry { eventID = triggerType };
        newEntry.callback.AddListener(action);
        trigger.triggers.Add(newEntry);
    }
}