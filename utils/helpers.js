import { Notifications } from 'expo';
import * as Permissions from 'expo-permissions';
import { AsyncStorage } from 'react-native';

const NOTIFICATION_KEY = 'Flashcards:notifications';

function createNotification() {
	return {
		title: 'Study time!',
		body: ' Make sure to study today!',
		ios: {
			sound: true
		},
		android: {
			sound: true,
			priority: 'high',
			sticky: false,
			vibrate: true
		}
	};
}

export function clearLocalNotification() {
	return AsyncStorage.removeItem(NOTIFICATION_KEY).then(Notifications.cancelAllScheduledNotificationsAsync);
}

export async function setLocalNotification() {
	AsyncStorage.getItem(NOTIFICATION_KEY).then(JSON.parse).then((data) => {
		if (data === null) {
			Permissions.askAsync(Permissions.NOTIFICATIONS).then(({ status }) => {
				if (status === 'granted') {
					Notifications.cancelAllScheduledNotificationsAsync();

					let tomorrow = new Date();
					tomorrow.setDate(tomorrow.getDate() + 1);
					tomorrow.setHours(21);
					tomorrow.setMinutes(10);

					Notifications.scheduleLocalNotificationAsync(createNotification(), {
						time: tomorrow
					});

					AsyncStorage.setItem(NOTIFICATION_KEY, JSON.stringify(true));
				}
			});
		}
	});
}
