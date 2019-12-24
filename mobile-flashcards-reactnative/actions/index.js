import { RECEIVE_DECKS, ADD_DECK, ADD_CARD, DELETE_DECK } from './types';
import * as API from '../utils/api';

export function receiveDecks(decks) {
	return {
		type: RECEIVE_DECKS,
		decks
	};
}

export function addDeck(title) {
	return {
		type: ADD_DECK,
		title
	};
}

export function addCard(id, card) {
	return {
		type: ADD_CARD,
		card,
		id
	};
}

export function deleteDeck(title) {
	return {
		type: DELETE_DECK,
		title
	};
}

/* redux thunk functions */
export function getDecks() {
	return (dispatch) => {
		return API.getDecks().then((decks) => {
			const obj = JSON.parse(decks);
			dispatch(receiveDecks(obj));
		});
	};
}

export function createNewDeck(title) {
	return (dispatch) => {
		return API.saveDeckTitle(title).then(() => {
			dispatch(addDeck(title));
		});
	};
}

export function addNewCardToDeck(id, card) {
	return (dispatch) => {
		return API.addCardToDeck(id, card).then(() => {
			dispatch(addCard(id, card));
		});
	};
}

export function deleteExistingDeck(id) {
	return (dispatch) => {
		return API.deleteDeck(id)
			.then(() => {
				dispatch(deleteDeck(id));
			})
			.catch((error) => console.log(error));
	};
}
