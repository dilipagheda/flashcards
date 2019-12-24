import { AsyncStorage } from 'react-native';
const STORAGE_KEY = 'DECKS_STORAGE_KEY';

export function getDecks() {
	return AsyncStorage.getItem(STORAGE_KEY);
}

export function saveDeckTitle(title) {
	return AsyncStorage.mergeItem(
		STORAGE_KEY,
		JSON.stringify({
			[title]: {
				title,
				questions: []
			}
		})
	);
}

//id is same as title
export async function addCardToDeck(id, card) {
	const currentData = await AsyncStorage.getItem(STORAGE_KEY);
	currentQuestions = JSON.parse(currentData)[id].questions;
	return AsyncStorage.mergeItem(
		STORAGE_KEY,
		JSON.stringify({
			[id]: {
				id,
				questions: [ ...currentQuestions, card ]
			}
		})
	);
}

export async function deleteDeck(id) {
	const strData = await AsyncStorage.getItem(STORAGE_KEY);
	const data = JSON.parse(strData);
	data[id] = undefined;
	delete data[id];

	return AsyncStorage.setItem(STORAGE_KEY, JSON.stringify(data));
}

/* No need for below method as deck will be available from redux store
once it is loaded from asyncStorage */
// export function getDeck(){

// }
