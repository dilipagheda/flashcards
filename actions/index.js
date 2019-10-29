import { RECEIVE_DECKS, ADD_DECK, ADD_CARD, DELETE_DECK } from './types';

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

export function addCard(card) {
	return {
		type: ADD_CARD,
		card
	};
}

export function deleteDeck(title) {
	return {
		type: DELETE_DECK,
		title
	};
}
