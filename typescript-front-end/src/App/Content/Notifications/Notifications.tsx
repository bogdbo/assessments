import * as React from 'react';
import {Chrome} from "../Chrome";
import {loadNotifications} from "./utils";
import {Notification} from './Notification';

interface Props {
}

interface State {
  notifications?: Notification[];
}

class Notifications extends React.Component<Props, State> {
  constructor(props: Props) {
    super(props);
    this.state = {};
  }

  async componentDidMount(): Promise<void> {
    const notifications = await loadNotifications()
    this.setState({notifications});
  }

  render() {
    const notificationsLoaded = this.state.notifications != null;
    return (
      <Chrome>
        <h1>Notifications todo</h1>
        {!notificationsLoaded && "Loading" }
        {notificationsLoaded && this.state.notifications.map(n => {
          return (
            <span key={n.id}>{n.title} {n.body}</span>
          )
        })}
      </Chrome>
    )
  }
}

export {Notifications};
