import {callApi} from "../../Common/CallApi";
import {Notification} from "./Notification";

export function loadNotifications(): Promise<Notification[]> {
  return callApi<Notification[]>('http://localhost:5000/api/notifications');
}